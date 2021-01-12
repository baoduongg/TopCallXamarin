using System;
using Newtonsoft.Json;
using TopCallXamarin.Infrastructure.Networking.Bases;

namespace TopCallXamarin.Models.Responses
{
    public class UserResponseModel : ResponseBase
    {
        public UserResponseModel()
        {
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
