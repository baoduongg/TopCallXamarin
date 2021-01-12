using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace TopCallXamarin.Extentions
{
    public static class NavigationExtenstion
    {
        public static Task<IMaterialModalPage> DialogLoading(this TinyNavigationHelper.INavigationHelper navigationHelper, string Message)
        {
            var loadingDialogConfiguration = new MaterialLoadingDialogConfiguration();
            loadingDialogConfiguration.BackgroundColor = Color.White;
            loadingDialogConfiguration.MessageTextColor = Color.Black;
            loadingDialogConfiguration.TintColor = (Color)Application.Current.Resources["Primary"];

            return MaterialDialog.Instance.LoadingDialogAsync(message: Message,
                                                 configuration: loadingDialogConfiguration);
        }

        public static Task SnackbarAsync(this TinyNavigationHelper.INavigationHelper navigationHelper, string Message, int msDuration = 2750)
        {
            var loadingDialogConfiguration = new MaterialSnackbarConfiguration();
            loadingDialogConfiguration.BackgroundColor = Color.White;
            loadingDialogConfiguration.MessageTextColor = Color.Black;
            loadingDialogConfiguration.TintColor = (Color)Application.Current.Resources["Primary"];

            return MaterialDialog.Instance.SnackbarAsync(message: Message, msDuration,
                                                 configuration: loadingDialogConfiguration);
        }

        public static Task<bool> SnackbarAsync(this TinyNavigationHelper.INavigationHelper navigationHelper, string Message, string actionButtonText,  int msDuration = 2750)
        {
            var loadingDialogConfiguration = new MaterialSnackbarConfiguration();
            loadingDialogConfiguration.BackgroundColor = Color.White;
            loadingDialogConfiguration.MessageTextColor = Color.Black;
            loadingDialogConfiguration.TintColor = (Color)Application.Current.Resources["Primary"];

            return MaterialDialog.Instance.SnackbarAsync(message: Message, actionButtonText, msDuration, configuration: loadingDialogConfiguration);
        }
    }
}

