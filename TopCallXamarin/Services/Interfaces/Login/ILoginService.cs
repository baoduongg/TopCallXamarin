using System;
using System.Threading;
using System.Threading.Tasks;
using TopCallXamarin.Models.Storage;
using TopCallXamarin.Models.UI;

namespace TopCallXamarin.Services.Interfaces.Login
{
    public interface ILoginService
    {
        Task<UserInfoUiModel> Auth(string username, string password, bool isRememberMe, CancellationToken token);
        Task<UserStorageModel> GetAuthInfo();

    }
}
