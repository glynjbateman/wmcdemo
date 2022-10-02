using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wmcdemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wmcdemo.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginContentPage : ContentPageBase
    {
        public override Type ViewModelType => typeof(LoginViewModel);
        public LoginContentPage() : base()
        {
            InitializeComponent();
        }
    }
}