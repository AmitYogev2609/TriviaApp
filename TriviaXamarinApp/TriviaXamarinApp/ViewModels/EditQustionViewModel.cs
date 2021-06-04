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
    class EditQustionViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
       
       
        public string RightAnswer
        {
            get => rightanswer; set
            {
                if (value != rightanswer)
                {
                    rightanswer = value;
                    OnPropertyChanged(nameof(RightAnswer));
                }
            }
        }
        private string rightanswer;
        public string Qustion
        {
            get => qustion; set
            {
                if (value != qustion)
                {
                    qustion = value;
                    OnPropertyChanged(nameof(Qustion));
                }
            }
        }
        private string qustion;
        public bool IsVisible
        {
            get => isvisible; set
            {
                if (value != isvisible)
                {
                    isvisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }
        private bool isvisible;
        public string WrongAnswer1
        {
            get => wrong1; set
            {
                if (value != wrong1)
                {
                    wrong1 = value;
                    OnPropertyChanged(nameof(WrongAnswer1));
                }
            }
        }
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
       
        private AmericanQuestion Copy;
        public EditQustionViewModel(AmericanQuestion q)
        {
            this.Copy = q;
            this.Qustion = q.QText;
            this.RightAnswer = q.CorrectAnswer;
            this.WrongAnswer1 = q.OtherAnswers[0];
            this.WrongAnswer2 = q.OtherAnswers[1];
            this.WrongAnswer3 = q.OtherAnswers[2];
            IsVisible = false;
            isvisible = false;

        }
        public ICommand EditCommand => new Command(EdtiQustion);
        public async void EdtiQustion()
        {
            List<string> list = new List<string>();

            list.Add(WrongAnswer1);
            list.Add(WrongAnswer2);
            list.Add(WrongAnswer3);
            AmericanQuestion question = new AmericanQuestion()
            {
                CreatorNickName = Copy.CreatorNickName,
                QText = Qustion,
                CorrectAnswer = RightAnswer,
                OtherAnswers = list.ToArray()
            };
            try
            {
                bool isRemove = await TriviaWebAPIProxy.CreateProxy().DeleteQuestion(Copy);
                bool isAdd = await TriviaWebAPIProxy.CreateProxy().PostNewQuestion(question);
                if (isAdd && isRemove)
                {

                    int x= ((App)App.Current).CurrnetUser.Questions.IndexOf(Copy);
                    ((App)App.Current).CurrnetUser.Questions[x] = question;

                    NavigateBackToPageEvent?.Invoke();



                }
            }
            catch(Exception E)
            {
                IsVisible = true;
            }
            
        }
        public event Action NavigateBackToPageEvent;
    }
}
