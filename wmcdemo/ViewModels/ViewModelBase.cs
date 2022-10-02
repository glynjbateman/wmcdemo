using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace wmcdemo.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public abstract string Title { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public abstract void OnAppearing();
        public abstract void OnDissappearing();
    }
}
