using System;
using System.Collections.Generic;
using TopCallXamarin.ViewModels;
using TopCallXamarin.Views;
using Xamarin.Forms;

namespace TopCallXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

        }

    }
}
