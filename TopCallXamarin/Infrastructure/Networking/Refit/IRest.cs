using System;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using TopCallXamarin.Infrastructure.Networking.Bases;

namespace TopCallXamarin.Infrastructure.Networking.Refit
{
    public interface IRest<TApi>
    {
        /// <summary>
        /// Do api call with retry and error handling
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="actionFactor"></param>
        /// <param name="retryMode"></param>
        /// <returns></returns>
        Task<TResult> CallWithRetry<TResult>(Func<TApi, Task<IApiResponse<TResult>>> taskFunction, CancellationToken token, RetryMode retryMode = RetryMode.Confirm) where TResult : ResponseBase;
    }
}
