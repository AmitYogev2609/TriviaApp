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
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            this.BindingContext = new SignUpViewModel ();
            ((SignUpViewModel)this.BindingContext).NavigateToPageEvent += PopNavigateToAsync;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((SignUpViewModel)this.BindingContext).rest();
        }
        public async void PopNavigateToAsync()
        {
            await Navigation.PopAsync();
        }
    }
}