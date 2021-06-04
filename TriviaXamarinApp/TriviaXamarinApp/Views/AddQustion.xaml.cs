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
    public partial class AddQustion : ContentPage
    {
        public AddQustion()
        {
            InitializeComponent();
            AddQustionViewModel context = new AddQustionViewModel();
            context.NavigateBackToPageEvent += BackToMain;
            this.BindingContext = context;
        }
        public async void BackToMain()
        {
            await Navigation.PopAsync();
        }
    }
}