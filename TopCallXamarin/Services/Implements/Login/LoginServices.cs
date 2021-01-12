using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinyMvvm.IoC;
using TopCallXamarin.CommonConst;
using TopCallXamarin.Infrastructure.Networking.Refit;
using TopCallXamarin.Models.Responses;
using TopCallXamarin.Models.Storage;
using TopCallXamarin.Models.UI;
using TopCallXamarin.Services.ApiDefinitions.Login;
using TopCallXamarin.Services.Interfaces.Login;
using TopCallXamarin.Services.Interfaces.Storage;

namespace TopCallXamarin.Services.Implements.Login
{
    public class LoginServices : ILoginService
    {
        public LoginServices()
        {
        }

        public async Task<UserInfoUiModel> Auth(string username, string password, bool isRememberMe, CancellationToken token)
        {
            var authHeader = $"Basic {Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password))}";

            var rateListApi = Resolver.Resolve<IRest<ILoginApi>>();
            var response = await rateListApi.CallWithRetry(api => api.Auth(authHeader, token), token);
            if(response != null)
            {
                if(!string.IsNullOrEmpty(response.AccessToken) && isRememberMe)
                {
                    await SaveAuthInfo(new UserStorageModel
                    {
                        Username = isRememberMe ? username :  string.Empty,
                        Password = isRememberMe ? password : string.Empty,
                        IsRememberMe = isRememberMe
                    });
                }

                return UserInfoUiModel.FromResponse(response);
            }
            return null;
        }

        public async Task<UserStorageModel> GetAuthInfo()
        {
            var storageService = Resolver.Resolve<IStorageService>();
            return await storageService.GetSecureOrCreateAsync(StorageKeys.LoginKey, new UserStorageModel());
        }

        public async Task SaveAuthInfo(UserStorageModel userStorageModel)
        {
            var storageService = Resolver.Resolve<IStorageService>();
            await storageService.SetSecureAsync(StorageKeys.LoginKey, userStorageModel);
        }
    }
}
