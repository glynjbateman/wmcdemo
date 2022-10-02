using Nancy.TinyIoc;
using System;
using wmcdemo.ContentPages;
using wmcdemo.Services.Implementations;
using wmcdemo.Services.Interfaces;
using wmcdemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wmcdemo
{
    public partial class App : Application
    {
        public static TinyIoCContainer DIContainer;
        public App()
        {
            InitializeComponent();

            //Dependency Injection Setup.
            DIContainer = new TinyIoCContainer();

            //Services
            DIContainer.Register<ILoginService, LoginService>().AsSingleton();
            DIContainer.Register<INavigationService, NavigationService>().AsSingleton();
            DIContainer.Register<ILocalDbService, RealmDbService>().AsSingleton();
            DIContainer.Register<IMediaPicker, MediaPicker>().AsSingleton();

            //View Models
            DIContainer.Register<LoginViewModel>().AsSingleton();
            DIContainer.Register<ExpensesViewModel>().AsSingleton();

            //Navigate To Login Page By Default.
            MainPage = new NavigationPage(new LoginContentPage());
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
