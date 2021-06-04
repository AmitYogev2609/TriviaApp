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
    class SignUpViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string Email { get=>email; set
            {
                if(value!=email)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            } }
        private string email;
        public string NickName { get=>nickname; set
            {
                if(value!=nickname)
                {
                    nickname = value;
                    OnPropertyChanged(nameof(NickName));
                }
            } }
        private string nickname;
        public string Password { get=>pass; set
            {
                if(value!=pass)
                {
                    pass = value;
                    OnPropertyChanged(nameof(Password));
                }
            } }
        private string pass;
        public ICommand SignUp => new Command(signUp);
        public bool IsVisible { get=>isvisible; set
            {
                if(value!=isvisible)
                {
                    isvisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            } }
        private bool isvisible;
        public SignUpViewModel()
        {
            IsVisible = false;
        }
        public event Action NavigateToPageEvent;
        public async void signUp()
        {
            User user = new User()
            {
                Email = this.Email,
                NickName = this.NickName,
                Password = this.Password
                

            };

            
            if(await TriviaWebAPIProxy.CreateProxy().RegisterUser(user))
            {
                NavigateToPageEvent?.Invoke();
                ((App)App.Current).CurrnetUser = user;
               LoginViewModel.openMainPage();
            }
            else
            {
                IsVisible=true;
            }
        }
    }
}
