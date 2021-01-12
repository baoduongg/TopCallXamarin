using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using TopCallXamarin.Infrastructure.Networking.Bases;
using Xamarin.Essentials;
using XF.Material.Forms.UI.Dialogs;

namespace TopCallXamarin.Infrastructure.Networking.Refit
{
    public class RestFactory : IRestFactory
    {
        private const int TimeoutInSeconds = 10;

        public RestFactory()
        {
        }

        public NetworkAccess GetNetworkState()
        {
            return Connectivity.NetworkAccess;
        }

        public TApi Build<TApi>()
        {
            var name = typeof(TApi).FullName;
            //if (_cachedApis.ContainsKey(name))
            //    return (TApi)_cachedApis[name];

            var client = GetOrCreateClient<TApi>();
            var api = BuildInternal<TApi>(client);
            return api;
        }

        private TApi BuildInternal<TApi>(HttpClient client)
        {
            var defaultSettings = new RefitSettings
            {
                
            };
            var apiGateway = RestService.For<TApi>(client, defaultSettings);
            return apiGateway;
        }

        private HttpClient GetOrCreateClient<TApi>()
        {
            //var shouldHandlingRetry = ShouldHandlingRetry<TApi>();
            //var handler = new ExtendedNativeMessageHandler(UriContractKey, _logService, (uri, should) => PrepareToCallAsync(uri, shouldHandlingRetry)) // Use native handler for better perfomance
            //{
            //    DisableCaching = true,
            //    AllowAutoRedirect = false,
            //    //ShouldHandlingRetry = shouldHandlingRetry,
            //    Timeout = TimeSpan.FromSeconds(TimeoutInSeconds) // not reliable, but for safety
            //    /* ==================================================================================================
            //     * The property "MessageHandler.TimeOut", "HttpClient.TimeOut" is not reliable
            //     * => use CancellationToken instead
            //     * ================================================================================================*/
            //};
            var handler = new ExtendedNativeMessageHandler
            {
                AllowAutoRedirect = false,
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    //bypass
                    return true;
                }

            };

            var client = new HttpClient(handler, true)
            {
                BaseAddress = new Uri(GetUrl<TApi>()),
                Timeout = TimeSpan.FromSeconds(TimeoutInSeconds)
                // https://stackoverflow.com/questions/58339122/c-sharp-httpclient-with-httpclienthandler-cancellation-not-working
                // https://forums.xamarin.com/discussion/5941/system-net-http-httpclient-timeout-seems-to-be-ignored
            };
            return client;
        }

        private string GetUrl<TApi>()
        {
            return ApiHost.MainHost + ApiHost.DefaultServicePrefix;
        }

        Task<bool?> _mainConfirmTask;
        TaskCompletionSource<bool> _dismissionCompletionSource;
        TaskCompletionSource<bool> _resultSetterCompletionSource;
        public Task<bool?> ConfirmOnMainThreadAsync(bool wasFailed, Uri apiEndpoint)
        {
            EnsureInitialized();
            //var completionSource = Enqueue(requestedUri);
            if (_mainConfirmTask == null)
            {
                _mainConfirmTask = MainThread.InvokeOnMainThreadAsync(() =>
                {
                    return MaterialDialog.Instance.ConfirmAsync(wasFailed ? _globalizedErrorMessage : _globalizedTimeoutMessage, null, _globalizedAccept, _globalizedCancel);
                });
            }
            return _mainConfirmTask;
        }

        private string _globalizedErrorMessage, _globalizedTimeoutMessage, _globalizedAccept, _globalizedCancel, _globalizedServerErrorMsg;

        public string DefaultServerErrorMessage => _globalizedServerErrorMsg ?? throw new ArgumentException($"You MUST call {nameof(IRestFactory)}.{nameof(Init)}(...) before use");

        public void Init(string errorMessage, string timeoutMessage, string acceptButton, string cancelButton, string defaulServerErrorMsg)
        {
            _globalizedErrorMessage = errorMessage;
            _globalizedAccept = acceptButton;
            _globalizedCancel = cancelButton;
            _globalizedTimeoutMessage = timeoutMessage;
            _globalizedServerErrorMsg = defaulServerErrorMsg;
        }

        void EnsureInitialized()
        {
            if (string.IsNullOrEmpty(_globalizedAccept)
                || string.IsNullOrEmpty(_globalizedErrorMessage)
                || string.IsNullOrEmpty(_globalizedTimeoutMessage)
                || string.IsNullOrEmpty(_globalizedCancel))
                throw new ArgumentException($"You MUST call {nameof(IRestFactory)}.{nameof(Init)}(...) before use");
        }
    }
}
