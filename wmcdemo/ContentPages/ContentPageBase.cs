using System;
using System.Collections.Generic;
using System.Text;
using wmcdemo.ViewModels;
using Xamarin.Forms;

namespace wmcdemo.ContentPages
{
    public abstract class ContentPageBase : ContentPage
    {
        public abstract Type ViewModelType { get; }

        ViewModelBase ViewModel;

        public ContentPageBase()
        {
            ViewModel = App.DIContainer.Resolve(ViewModelType) as ViewModelBase;
            this.BindingContext = ViewModel;
            this.Title = ViewModel.Title;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.OnDissappearing();
        }
    }
}
