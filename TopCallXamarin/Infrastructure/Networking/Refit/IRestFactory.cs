using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TopCallXamarin.Infrastructure.Networking.Refit
{
    public interface IRestFactory
    {

        /// <summary>
        /// Get from cached first or create new
        /// </summary>
        /// <typeparam name="TApi"></typeparam>
        /// <returns></returns>
        TApi Build<TApi>();

        void Init(string errorMessage, string timeoutMessage, string acceptButton, string cancelButton, string defaulServerErrorMsg);

        Task<bool?> ConfirmOnMainThreadAsync(bool wasFailed, Uri apiEndpoint);

        string DefaultServerErrorMessage { get; }

        NetworkAccess GetNetworkState();
    }
}