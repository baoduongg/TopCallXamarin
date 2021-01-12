using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TinyMvvm;
using TopCallXamarin.Models.UI;
using TopCallXamarin.Resources;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;
using TopCallXamarin.Extentions;
namespace TopCallXamarin.ViewModels
{
    public class BaseViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private static TaskCompletionSource<bool> _processorTcs = null;
        public async virtual Task<bool> ProcessErrorAsync(BaseUiModel dto)
        {

            if (await NoInterNet(dto.IsNetWork))
            {
                return false;
            }
            return true;
        }


        async Task<bool> NoInterNet(Xamarin.Essentials.NetworkAccess isNetWork)
        {
            switch (isNetWork)
            {
                case Xamarin.Essentials.NetworkAccess.Unknown:
                case Xamarin.Essentials.NetworkAccess.None:
                case Xamarin.Essentials.NetworkAccess.Local:
                case Xamarin.Essentials.NetworkAccess.ConstrainedInternet:
                    await Navigation.SnackbarAsync(AppResources.NoConnection);
                    return true;
                case Xamarin.Essentials.NetworkAccess.Internet:
                    return false;
            }
            return false;
        }

    }
}

