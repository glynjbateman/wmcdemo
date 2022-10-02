using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using wmcdemo.ContentPages;
using wmcdemo.Services.Interfaces;

namespace wmcdemo.Services.Implementations
{
    public class NavigationService : INavigationService
    {
        public async Task GoToExpenses()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ExpensesContentPage());
        }

        public async Task NavigateBack()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
