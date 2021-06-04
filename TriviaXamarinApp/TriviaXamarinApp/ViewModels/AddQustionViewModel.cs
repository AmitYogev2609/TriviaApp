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

namespace TriviaXamarinApp.ViewModels
{
    class AddQustionViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<string> WrongAnswerList { get; set; }
        public string RightAnswer { get=>rightanswer; set
            {
                if (value != rightanswer)
                {
                    rightanswer = value;
                    OnPropertyChanged(nameof(RightAnswer));
                }
            } }
        private string rightanswer;
        public string Qustion { get=>qustion; set
            {
                if(value!=qustion)
                {
                    qustion = value;
                    OnPropertyChanged(nameof(Qustion));
                }
            } }
        private string qustion;
        public bool IsVisible { get=>isvisible; set
            {
                if(value!=isvisible)
                {
                    isvisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            } }
        private bool isvisible;
        public string WrongAnswer1 { get=>wrong1; set
            {
                if(value!=wrong1)
                {
                    wrong1 = value;
                    OnPropertyChanged(nameof(WrongAnswer1));
                }
            } }
        private string wrong1; 
        public string WrongAnswer2
        {
            get => wrong2; set
            {
                if (value != wrong2)
                {
                    wrong2 = value;
                    OnPropertyChanged(nameof(WrongAnswer2));
                }
            }
        }
        private string wrong2;
        public string WrongAnswer3
        {
            get => wrong3; set
            {
                if (value != wrong3)
                {
                    wrong3 = value;
                    OnPropertyChanged(nameof(WrongAnswer3));
                }
            }
        }
        private string wrong3;
        public AddQustionViewModel()
        {
            
            
        }
        public ICommand AddCommand => new Command(AddQustion);
        public async void AddQustion()
        {
            List<string> list = new List<string>();
            
                list.Add(WrongAnswer1);
            list.Add(WrongAnswer2);
            list.Add(WrongAnswer3);
            AmericanQuestion question = new AmericanQuestion()
            {
                CreatorNickName= ((App)App.Current).CurrnetUser.NickName,
                QText=Qustion,
                CorrectAnswer=RightAnswer,
                OtherAnswers=list.ToArray()
            };
            try
            {
                bool IsAdd = await TriviaWebAPIProxy.CreateProxy().PostNewQuestion(question);
                if (IsAdd)
                {
                    ((App)App.Current).CurrnetUser.Questions.Add(question);
                   
                    NavigateBackToPageEvent?.Invoke();
                }
                else
                {
                    IsVisible = true;
                }
            }
            catch(Exception e)
            {
                
            }
        }
        public event Action NavigateBackToPageEvent;
    }
}
