using System;
using Newtonsoft.Json;

namespace TopCallXamarin.Models.Storage
{
    public class UserStorageModel
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("IsRememberMe")]
        public bool IsRememberMe { get; set; }
    }
}
