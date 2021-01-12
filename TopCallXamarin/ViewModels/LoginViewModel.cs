using TopCallXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using TinyMvvm.IoC;
using TopCallXamarin.Services.Interfaces.Login;
using System.Threading;
using TinyMvvm;
using TopCallXamarin.Resources;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;
using XF.Material.Forms.Resources;
using TopCallXamarin.Extentions;
using XF.Material.Forms;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TopCallXamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        CancellationTokenSource _ctsLogin;

        string _username = string.Empty;
        public string Username
        {
            get => _username;
            set {
                MsgWrongPassword = MsgWrongUsername = string.Empty;
                IsWrongPassword = IsWrongUsername = false;
                Set(ref _username, value);
            }
        }

        string _password = string.Empty;
        public string Password
        {
            get => _password;
            set {
                MsgWrongPassword = MsgWrongUsername = string.Empty;
                IsWrongPassword = IsWrongUsername = false;
                Set(ref _password, value);
            }
        }

        bool _isRememberMe = false;
        public bool IsRememberMe
        {
            get => _isRememberMe;
            set { Set(ref _isRememberMe, value); }
        }

        bool _isWrongUsername = false;
        public bool IsWrongUsername
        {
            get => _isWrongUsername;
            set { Set(ref _isWrongUsername, value); }
        }

        bool _isWrongPassword = false;
        public bool IsWrongPassword
        {
            get => _isWrongPassword;
            set { Set(ref _isWrongPassword, value); }
        }

        string _msgWrongPassword = string.Empty;
        public string MsgWrongPassword
        {
            get => _msgWrongPassword;
            set { Set(ref _msgWrongPassword, value); }
        }

        string _msgWrongUsername = string.Empty;
        public string MsgWrongUsername
        {
            get => _msgWrongUsername;
            set { Set(ref _msgWrongUsername, value); }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        public override Task Initialize()
        {
            GetAuthInfo();
            return base.Initialize();
        }

        public override Task OnFirstAppear()
        {

            return base.OnFirstAppear();
        }

        private async void OnLoginClicked(object obj)
        {
            await ActionLogin();
        }

        void GetAuthInfo()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var loginService = Resolver.Resolve<ILoginService>();
                var rs = await loginService.GetAuthInfo();
                if (rs != null)
                {
                    Username = rs.Username;
                    Password = rs.Password;
                    IsRememberMe = rs.IsRememberMe;
                }
            });
        }

        async Task ActionLogin()
        {
            if (!Validate(Username, Password))
                return;

            _ctsLogin?.Cancel();
            _ctsLogin = new CancellationTokenSource();

            var dialogLoading = await Navigation.DialogLoading(AppResources.Loading);
            var loginService = Resolver.Resolve<ILoginService>();
            var result = await loginService.Auth(Username, Password, true, _ctsLogin.Token);
            if (await base.ProcessErrorAsync(result))
            {
                if (!string.IsNullOrEmpty(result.AccessToken))
                {
                    await Navigation.NavigateToAsync($"//{ViewNames.Main}");
                }
                else
                {
                    MsgWrongPassword = AppResources.UsernameOrPasswordWrong;
                    IsWrongPassword = IsWrongUsername = true;
                }
            }
            await dialogLoading.DismissAsync();
        }

        bool Validate(string username, string password)
        {
            if (username != null || password != null)
            {
                if (username.Length < 2 || password.Length < 4 )
                {
                    MsgWrongPassword = AppResources.UsernameOrPasswordWrong;
                    IsWrongPassword = IsWrongUsername = true;
                    return false;
                }
            }
                
            return true;
        }
    }
}
