using System;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using TopCallXamarin.Models.Responses;

namespace TopCallXamarin.Services.ApiDefinitions.Login
{
    public interface ILoginApi
    {
        [Post("/auth")]
        Task<IApiResponse<UserResponseModel>> Auth([Header("Authorization")] string authorization, CancellationToken token);
    }
}
