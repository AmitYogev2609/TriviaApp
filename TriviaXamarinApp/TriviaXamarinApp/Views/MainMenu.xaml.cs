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
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
            MainMenuViewModel context = new MainMenuViewModel();
            context.NavigateToPageEvent += MoveToAddQu;
            this.BindingContext = context;
            NavigationPage.SetHasNavigationBar(this, false);  // Hide nav bar
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MainMenuViewModel)this.BindingContext).Checkthree();

        }
        public async void MoveToAddQu(Page p)
        {
            await Navigation.PushAsync(p);
        }
        

    }
}