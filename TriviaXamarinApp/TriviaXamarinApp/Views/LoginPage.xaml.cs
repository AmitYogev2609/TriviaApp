using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage( )
        {
            InitializeComponent();
            LoginViewModel context = new LoginViewModel();
            context.NavigateToPageEvent += NavigateToAsync;

            this.BindingContext = context;
            
        }
        public async void NavigateToAsync(Page p)
        {
            await Navigation.PushAsync(p);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((LoginViewModel)this.BindingContext).Reset();
        }
    }
}