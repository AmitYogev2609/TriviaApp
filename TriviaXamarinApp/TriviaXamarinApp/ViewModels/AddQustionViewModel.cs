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
        public AddQustionViewModel()
        {
            WrongAnswerList = new ObservableCollection<string>();
            WrongAnswerList.Add("");
            WrongAnswerList.Add("");
            WrongAnswerList.Add("");
            
        }
        public ICommand AddCommand => new Command(AddQustion);
        public async void AddQustion()
        {
            List<string> list = new List<string>();
            foreach (var item in WrongAnswerList)
            {
                list.Add(item);
            }
            AmericanQuestion question = new AmericanQuestion()
            {
                CreatorNickName= ((App)App.Current).CurrnetUser.NickName,
                QText=Qustion,
                CorrectAnswer=RightAnswer,
                OtherAnswers=list.ToArray()
            };
            bool IsAdd = await TriviaWebAPIProxy.CreateProxy().PostNewQuestion(question);
            if(IsAdd)
            {
                NavigateBackToPageEvent?.Invoke();
            }
            else
            {
                IsVisible = true;
            }
        }
        public event Action NavigateBackToPageEvent;
    }
}
