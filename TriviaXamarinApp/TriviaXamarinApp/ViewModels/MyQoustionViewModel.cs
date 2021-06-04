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
    class MyQoustionViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<AmericanQuestion> QuestionsList { get; set; }
        public MyQoustionViewModel()
        {
            QuestionsList = new ObservableCollection<AmericanQuestion>();
            
        }
        public AmericanQuestion SelctedQuestion { get=>selcted; set
            {
                if(value!=selcted)
                {
                    selcted = value;
                    OnPropertyChanged(nameof(SelctedQuestion));
                }
            } }
        private AmericanQuestion selcted;
        public ICommand DeleteCommand => new Command<AmericanQuestion>(Delete);
        public ICommand EditCommand=> new Command<AmericanQuestion>(edite);
        public async void Delete(AmericanQuestion question)
        {
            try
            { 
            this.QuestionsList.Remove(question);
            ((App)App.Current).CurrnetUser.Questions.Remove(question);
                
            bool iscon = await TriviaWebAPIProxy.CreateProxy().DeleteQuestion(question);
            }
            catch(Exception e) { }
        }
        public void GetQustion()
        {
            QuestionsList.Clear();
            if((((App)App.Current).CurrnetUser)!=null)
            {
               
                    foreach (var item in ((App)App.Current).CurrnetUser.Questions)
                    {
                         this.QuestionsList.Add(item);
                    }
            }
        }
        public event Action<Page> NavigateToPageEvent;
        public void edite(AmericanQuestion question)
        {
            Page p = new EditQustion(question);
            NavigateToPageEvent?.Invoke(p);
        }
        
    }
}
