using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using System.Security.Cryptography;
using System.ComponentModel;
using TriviaXamarinApp.Views;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.ViewModels
{
    class LoginViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public bool IsVisible { get=>isvisible; set
            { 
                if(value!=isvisible)
                {
                    isvisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            } }
        private bool isvisible;
        public bool LogVis { get=>logvis; set
            {
                if(value!=logvis)
                {
                    logvis = value;
                    OnPropertyChanged(nameof(LogVis));
                }
            } }
        private bool logvis;
        public string Email { get=>email; set 
            {
                if(value!=email)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            } }
        private string email;
        public string Password { get=>passweord; set
            {
                if(value!=passweord)
                {
                    passweord = value;
                    OnPropertyChanged(nameof(Password));
                }
            } }
        private string passweord;
        
        public LoginViewModel()
        {
            IsVisible = false;
            LogVis = true;
            //this.t = t;
            
            erorMesVis = false;
        }
        public ICommand LogInVisible => new Command(LogInVis);
        public ICommand SignUp => new Command(movetosign);
        public ICommand LogIn => new Command(Login);
        public void LogInVis()
        {
            this.IsVisible = true;
            LogVis = false;
        }
        public event Action<Page> NavigateToPageEvent;
        public  void movetosign()
        {
            Page sign = new SignUp();
            
           
                NavigateToPageEvent?.Invoke(sign);

           
        }
        public string ErrorMes { get=>eMes; set
            {
                if(value!=eMes)
                {
                    eMes = value;
                    OnPropertyChanged(nameof(ErrorMes));
                }
            } }
        public bool erorMesVis { get=>erorvis; set
            { 
             if(value!=erorvis)
                {
                    erorvis = value;
                    OnPropertyChanged(nameof(erorMesVis));
                }
            } }
        private bool erorvis;
        private string eMes;
        public async void Login()
        {
            
           ((App)App.Current).CurrnetUser = await TriviaWebAPIProxy.CreateProxy().LoginAsync(Email, Password);
            
      
            if(((App)App.Current).CurrnetUser == null)
            {
                ErrorMes = "worng email or password";
                erorMesVis = true;
            }
            else 
            {
                openMainPage();
            }
        }
        public static void openMainPage()
        {
            
            ((App)App.Current).MainPage = ((App)App.Current).tabbed;
        }
        public void Reset()
        {
            IsVisible = false;
            LogVis = true;
            erorMesVis = false;
            this.Email = "";
            this.Password = "";
        }
    }
}
