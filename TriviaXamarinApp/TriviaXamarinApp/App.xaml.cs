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
        
        public User CurrnetUser { get; set; }
        public Page intial { get; set; }
        public Page login { get; set; }
        public bool IsNew { get; set; }
        public Page tabbed { get; set; }
        public App()
        {
            InitializeComponent();

            
            //MainPage = new NavigationPage(new StartPage());
            MainPage = new NavigationPage(new StartPage());
            intial = MainPage;
            login = new NavigationPage(new LoginPage());
            IsNew = false;
            tabbed = new NavigationPage(new TabbedPage1());
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
