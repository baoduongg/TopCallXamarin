using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using TinyMvvm.IoC;
using TopCallXamarin.Infrastructure.Networking.Bases;

namespace TopCallXamarin.Infrastructure.Networking.Refit
{
    public class RestApiWrapper<TApi> : IRest<TApi>
    {
        private enum PhysicalResultInternal
        {
            Failed,
            Canceled,
            Timeout,
            Succeeded
        }

        private readonly IRestFactory _restFactory;

        public RestApiWrapper()
        {
            _restFactory = Resolver.Resolve<IRestFactory>();
        }

        public async Task<TResult> CallWithRetry<TResult>(Func<TApi, Task<global::Refit.IApiResponse<TResult>>> taskFunction, CancellationToken token, RetryMode retryMode = RetryMode.Confirm) where TResult : ResponseBase
        {
            if (taskFunction == null)
                throw new ArgumentNullException(nameof(taskFunction));
            switch (retryMode)
            {
                case RetryMode.Confirm:
                    using (var callWithConfirmationTask = CallWithConfirmation(taskFunction, token))
                    {
                        var rs = await callWithConfirmationTask;
                        return rs;
                    }
                case RetryMode.None:
                    using (var callInSilentTask = CallInSilent(taskFunction, token))
                    {
                        var rs = await callInSilentTask;
                        return rs;
                    }
                default:
                    /* ==================================================================================================
                     * the retry mode is not supported yet!
                     * ================================================================================================*/
                    throw new NotSupportedException($"The retry mode '{retryMode}' is not supported yet!");
            }
        }

        private async Task<TResponseBase> CallWithConfirmation<TResponseBase>(Func<TApi, Task<IApiResponse<TResponseBase>>> taskFunction, CancellationToken token) where TResponseBase : ResponseBase
        {
            var result = default(TResponseBase);
            var internalPhysical = PhysicalResultInternal.Succeeded;
            var requestedUri = default(Uri);
            var isNetwork = _restFactory.GetNetworkState();
            result = Activator.CreateInstance<TResponseBase>();
            result.IsNetWork = isNetwork;
            if (isNetwork == Xamarin.Essentials.NetworkAccess.Internet)
            {
                do
                {
                    try
                    {
                        if (internalPhysical == PhysicalResultInternal.Failed || internalPhysical == PhysicalResultInternal.Timeout)
                        {
                            if (requestedUri == null)
                                break;
                            var retry = await _restFactory.ConfirmOnMainThreadAsync(internalPhysical == PhysicalResultInternal.Failed, requestedUri) ?? false;
                            if (!retry)
                                break;
                        }
                        using (var actionTask = ActionSendAsync(taskFunction))
                        {
                            var apiResponse = await actionTask;
                            result = apiResponse.Content ?? Activator.CreateInstance<TResponseBase>();
                            if (result.SerializerError != null)
                            {
                                requestedUri = apiResponse.RequestMessage.RequestUri;
                                throw result.SerializerError;
                            }
                            PrepareResponse(result, apiResponse);
                        }
                        result.PhysicalResult = PhysicalResult.Succeeded;
                        internalPhysical = PhysicalResultInternal.Succeeded;
                    }
                    catch (OperationCanceledException ex)
                    {
                        result = Activator.CreateInstance<TResponseBase>();
                        result.PhysicalResult = PhysicalResult.Canceled;
                        internalPhysical = PhysicalResultInternal.Canceled;
                    }
                    catch (TimeoutException ex)
                    {
                        result = Activator.CreateInstance<TResponseBase>();
                        result.PhysicalResult = PhysicalResult.Failed;
                        internalPhysical = PhysicalResultInternal.Timeout;
                    }
                    catch (HttpRequestException ex)
                    {
                        result = Activator.CreateInstance<TResponseBase>();
                        result.PhysicalResult = PhysicalResult.Failed;
                        internalPhysical = PhysicalResultInternal.Failed;
                    }
                    catch (Exception ex)
                    {
                        result = Activator.CreateInstance<TResponseBase>();
                        result.PhysicalResult = PhysicalResult.Failed;
                        internalPhysical = PhysicalResultInternal.Failed;
                    }
                }
                while (internalPhysical == PhysicalResultInternal.Failed || internalPhysical == PhysicalResultInternal.Timeout);
            }
            result.IsNetWork = isNetwork;
            return result;
        }

        private async Task<TResponseBase> CallInSilent<TResponseBase>(Func<TApi, Task<IApiResponse<TResponseBase>>> taskFunction, CancellationToken token) where TResponseBase : ResponseBase
        {
            var result = default(TResponseBase);
            try
            {
                token.ThrowIfCancellationRequested();
                using (var actionTask = ActionSendAsync(taskFunction))
                {
                    var apiResponse = await actionTask;
                    result = apiResponse.Content ?? Activator.CreateInstance<TResponseBase>();
                    PrepareResponse(result, apiResponse);
                }
                result.PhysicalResult = PhysicalResult.Succeeded;
            }
            catch (OperationCanceledException ex)
            {
                result = Activator.CreateInstance<TResponseBase>();
                result.PhysicalResult = PhysicalResult.Canceled;
            }
            catch (TimeoutException ex)
            {
                result = Activator.CreateInstance<TResponseBase>();
                result.PhysicalResult = PhysicalResult.Failed;
            }
            catch (Exception ex)
            {
                result = Activator.CreateInstance<TResponseBase>();
                result.PhysicalResult = PhysicalResult.Failed;
            }
            return result;
        }


        private async Task<IApiResponse<TResponseBase>> ActionSendAsync<TResponseBase>(Func<TApi, Task<IApiResponse<TResponseBase>>> taskFunction) where TResponseBase : ResponseBase
        {
            var api = _restFactory.Build<TApi>();
            using var task = taskFunction(api); // retrieve the api task from task factory
            using var response = await task; // also include the json response serialization, also throw Newtonsoft.Json.JsonReaderException
            return response;
        }

        private void PrepareResponse<TResponseBase>(TResponseBase result, IApiResponse<TResponseBase> apiResponse) where TResponseBase : ResponseBase
        {
            result.StatusCode = (int)apiResponse.StatusCode;
            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                    // do nothing else
                    break;
                case HttpStatusCode.Found:
                    result.RedirectUrl = apiResponse.Headers.Location; // get the redirect url from response
                    break;
                default:
                    if (result.StatusCode >= 500 && result.StatusCode <= 599) // 5x series, use number instead of enum
                    {
                        var formatedMessage = $"{(string.IsNullOrEmpty(apiResponse.ReasonPhrase) ? _restFactory.DefaultServerErrorMessage : apiResponse.ReasonPhrase)}({result.StatusCode:n0})";
                        result.Message = formatedMessage;
                    }
                    break;
            }
        }
    }
}
