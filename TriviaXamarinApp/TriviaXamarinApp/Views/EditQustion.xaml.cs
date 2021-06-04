using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModels;
using TriviaXamarinApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditQustion : ContentPage
    {
        public EditQustion(AmericanQuestion q)
        {
            
            EditQustionViewModel context = new EditQustionViewModel(q);
            context.NavigateBackToPageEvent += Navigaiteback;
            this.BindingContext = context;
            InitializeComponent();
        }
        public async void Navigaiteback()
        {
            await Navigation.PopAsync();
        }
    }
}