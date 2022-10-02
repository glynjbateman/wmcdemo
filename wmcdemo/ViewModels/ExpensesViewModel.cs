using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using wmcdemo.Services.Interfaces;
using Xamarin.Forms;

namespace wmcdemo.ViewModels
{
    public class ExpensesViewModel : ViewModelBase
    {
        public override string Title => "Expenses";

        private INavigationService _navigationService;
        private IMediaPicker _mediaPicker;

        public ExpensesViewModel(INavigationService navigationService, IMediaPicker mediaPicker)
        {
            this._navigationService = navigationService;
            this._mediaPicker = mediaPicker;
        }

        private bool SelectingPhoto { get; set; }

        public ObservableCollection<ImageSource> Images { get; set; } = new ObservableCollection<ImageSource>();

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
                if (Fuel == 0 && Food == 0 && Parking == 0)
                {
                    return "";
                }

                return $"Total expense claim is {TotalExpenses.ToString("C")}.The highest category was {HighestCategory}.";
            }
        }

        public Command SelectPhotoCommand => new Command(async () =>
        {
            try
            {
                SelectingPhoto = true;
                Stream stream = await _mediaPicker.SelectPhoto();
                if (stream != null)
                {
                    Images.Add(ImageSource.FromStream(() => stream));
                }
            }
            catch (Exception ex) { }
            finally
            {
                SelectingPhoto = false;
            }
        });

        public override void OnAppearing() { }

        public override void OnDissappearing() 
        {
            if (!SelectingPhoto)
            {
                Images.Clear();
            }
        }
    }
}
