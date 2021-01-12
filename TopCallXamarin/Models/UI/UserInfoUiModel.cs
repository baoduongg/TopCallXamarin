using System;
using TopCallXamarin.Infrastructure.Networking.Bases;
using TopCallXamarin.Models.Responses;
using Xamarin.Essentials;

namespace TopCallXamarin.Models.UI
{
    public class UserInfoUiModel : BaseUiModel
    {
        public UserInfoUiModel(string id, string accessToken, string username, string email, NetworkAccess isNetWork, PhysicalResult physicalResult) : base(isNetWork, physicalResult)
        {
            Id = id;
            AccessToken = accessToken;
            AuthToken = accessToken;
            Username = username;
            Email = email;
        }

        public string Id { get; set; }
        public string AccessToken { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public static string AuthToken { get; set; }
        public static UserInfoUiModel FromResponse(UserResponseModel response)
        {
            var id = response?.Id ?? string.Empty;
            var accessToken = response?.AccessToken ?? string.Empty;
            var username = response?.Username ?? string.Empty;
            var email = response?.Email ?? string.Empty;
            return new UserInfoUiModel(id, accessToken, username, email, response.IsNetWork, response.PhysicalResult);
        }
    }
}
