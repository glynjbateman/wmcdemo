using System;
using System.Collections.Generic;
using System.Text;
using wmcdemo.Services.Interfaces;

namespace wmcdemo.ViewModels
{
    public class ExpensesViewModel : ViewModelBase
    {
        public override string Title => "Expenses";

        private INavigationService _navigationService;

        public ExpensesViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        private decimal _fuel { get; set; }
        public decimal Fuel
        {
            get
            {
                return _fuel;
            }
            set
            {
                _fuel = value;
                OnPropertyChanged();
                OnPropertyChanged("TotalExpensesString");
            }
        }

        private decimal _parking { get; set; }
        public decimal Parking
        {
            get
            {
                return _parking;
            }
            set
            {
                _parking = value;
                OnPropertyChanged();
                OnPropertyChanged("TotalExpensesString");
            }
        }

        private decimal _food { get; set; }
        public decimal Food
        {
            get
            {
                return _food;
            }
            set
            {
                _food = value;
                OnPropertyChanged();
                OnPropertyChanged("TotalExpensesString");
            }
        }

        public decimal TotalExpenses
        {
            get
            {
                return Fuel + Parking + Food;
            }
        }

        public string HighestCategory
        {
            get
            {
                if (Parking > Food && Parking > Fuel)
                {
                    return "Parking";
                }

                if (Food > Parking && Food > Fuel)
                {
                    return "Food";
                }
                if (Fuel > Parking && Fuel > Food)
                {
                    return "Fuel";
                }

                return "";
            }
        }

        public string TotalExpensesString
        {
            get
            {
                return $"Total expense claim is {TotalExpenses.ToString("C")}.The highest category was {HighestCategory}.";
            }
        }

        public override void OnAppearing() { }
    }
}
