using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TopCallXamarin.Views;
using TinyNavigationHelper;
using TinyNavigationHelper.Forms;
using System.Reflection;
using Autofac;
using TinyMvvm.Autofac;
using TinyMvvm.IoC;
using TinyMvvm;
using TopCallXamarin.Infrastructure.Networking.Refit;
using TopCallXamarin.Services.Interfaces.Login;
using TopCallXamarin.Services.Implements.Login;
using System.Threading;
using System.Globalization;
using TopCallXamarin.Resources;
using System.Linq;
using TopCallXamarin.Services.Implements.Storage;
using TopCallXamarin.Services.Interfaces.Storage;

namespace TopCallXamarin
{
    public partial class App : Application
    {

        public App()
        {
            var language = CultureInfo.InstalledUICulture; // get Language system
            //var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().First(element => element.EnglishName.Contains("")); // Default language Vietnamese
            Thread.CurrentThread.CurrentUICulture = language;
            AppResources.Culture = language;

            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            Sharpnado.MaterialFrame.Initializer.Initialize(false, false);
            var navigationHelper = new ShellNavigationHelper();

            var currentAssembly = Assembly.GetExecutingAssembly();
            navigationHelper.RegisterViewsInAssembly(currentAssembly);

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance<INavigationHelper>(navigationHelper);

            var appAssembly = typeof(App).GetTypeInfo().Assembly;
            containerBuilder.RegisterAssemblyTypes(appAssembly)
                   .Where(x => x.IsSubclassOf(typeof(Page)));

            containerBuilder.RegisterAssemblyTypes(appAssembly)
                   .Where(x => x.IsSubclassOf(typeof(ViewModelBase)));

            RegisterServices(containerBuilder, currentAssembly);

            Resolver.SetResolver(new AutofacResolver(containerBuilder.Build()));

            MainPage = new AppShell();
        }

        private void RegisterServices(ContainerBuilder containerBuilder, Assembly assembly)
        {
            containerBuilder.RegisterGeneric(typeof(RestApiWrapper<>)).As(typeof(IRest<>)).InstancePerDependency();
            containerBuilder.RegisterType<RestFactory>().As<IRestFactory>().InstancePerDependency();
            containerBuilder.RegisterType<LoginServices>().As<ILoginService>().InstancePerDependency();
            containerBuilder.RegisterType<StorageService>().As<IStorageService>().InstancePerDependency();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
