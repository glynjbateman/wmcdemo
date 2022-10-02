using System;
using System.Collections.Generic;
using System.Text;
using wmcdemo.Services.Interfaces;
using Xamarin.Forms;

namespace wmcdemo.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public override string Title => "Login";

        private ILoginService _loginService;
        private INavigationService _navigationService;
        private ILocalDbService _localDbService;

        public LoginViewModel(ILoginService loginService, INavigationService navigationService, ILocalDbService localdbService)
        {
            this._loginService = loginService;
            this._navigationService = navigationService;
            this._localDbService = localdbService;
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged();
                OnPropertyChanged("LoginEnabled");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
                OnPropertyChanged("LoginEnabled");
            }
        }

        public bool LoginEnabled
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Username)
                    && !string.IsNullOrWhiteSpace(Password);
            }
        }

        private bool _loginFailed = false;
        public bool LoginFailed
        {
            get
            {
                return _loginFailed;
            }
            set
            {
                _loginFailed = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand => new Command(async () =>
        {
            bool success = await _loginService.Login(Username, Password);
            if (success)
            {
                LoginFailed = false;
                await _localDbService.DeleteKeyValue("username");
                await _localDbService.WriteKeyValue("username", Username);
                await _navigationService.GoToExpenses();
            }
            else
            {
                LoginFailed = true;
            }
        });

        public async override void OnAppearing()
        {
            Username = await _localDbService.ReadKeyValue("username");
            Password = "";
        }

        public override void OnDissappearing() { }
    }
}
