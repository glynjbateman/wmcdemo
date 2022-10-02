using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace wmcdemo.Services.Interfaces
{
    public interface INavigationService
    {
        Task NavigateBack();
        Task GoToExpenses();
    }
}
