using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using System.Threading.Tasks;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp
{
    public partial class App : Application
    {
        public TriviaWebAPIProxy WebAPI { get; set; }
        public Page intial { get; set; }
        public Page login { get; set; }
        public App()
        {
            InitializeComponent();

            WebAPI = TriviaWebAPIProxy.CreateProxy();
            MainPage = new NavigationPage(new StartPage());
            intial = MainPage;
            login = new LoginPage();
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
