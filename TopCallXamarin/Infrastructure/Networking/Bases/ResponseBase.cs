using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Essentials;

namespace TopCallXamarin.Infrastructure.Networking.Bases
{
    public class ResponseBase
    {
        public ResponseBase()
        {
        }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        [JsonIgnore]
        public PhysicalResult PhysicalResult { get; set; }

        [JsonIgnore]
        public NetworkAccess IsNetWork { get; set; }

        [JsonIgnore]
        public Uri RedirectUrl { get; set; }

        [JsonIgnore]
        internal Exception SerializerError { get; private set; }

        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true; // prevent exception thrown at RestApiWrapper
            SerializerError = errorContext.Error;
        }

        public void OnError(Exception exception)
        {
            SerializerError = exception;
        }
    }

    public enum PhysicalResult
    {
        /// <summary>
        /// api call failed
        /// </summary>
        Failed,
        /// <summary>
        /// that mean recieved response from server.
        /// </summary>
        Succeeded,
        /// <summary>
        /// the api call was canceled
        /// </summary>
        Canceled
    }
}
