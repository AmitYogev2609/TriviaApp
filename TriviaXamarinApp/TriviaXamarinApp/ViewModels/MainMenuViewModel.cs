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
    class MainMenuViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Question
        {
            get => qustion; set
            {
                if (value != qustion)
                {
                    qustion = value;
                    OnPropertyChanged(nameof(Question));
                }
            }
        }
        public string qustion;
        public ObservableCollection<string> answerList { get; set; }
        public int NumCorrectQus
        {
            get => numco; set
            {
                if (value != numco)
                {
                    numco = value;
                    OnPropertyChanged(nameof(NumCorrectQus));
                }
            }
        }
        private int numco;
        public string CorectAnswer
        {
            get => corectAnswer; set
            {
                if (value != corectAnswer)
                {
                    corectAnswer = value;
                    OnPropertyChanged(nameof(CorectAnswer));
                }
            }
        }
        string corectAnswer;
        private string CurrnetCoAnswer;
        public Color ChangeColor
        {
            get => Color; set
            {
                if (value != Color)
                {
                    Color = value;
                    OnPropertyChanged(nameof(ChangeColor));
                }
            }
        }
        private Color Color;
        public string NickName { get=>nick;  }
        private string nick;
        public MainMenuViewModel()
        {
            answerList = new ObservableCollection<string>();
            numco = 0;

            ChangeColor = new Color();
            Color = new Color();
            if(((App)App.Current).IsNew != false)
            {
                Isvisible = true;
                Show = false;
            }
            else
            { 
            Isvisible = false;
               Show = true;
            }
            SetupQus();
            if(((App)App.Current).CurrnetUser!=null)
            {
                nick = ((App)App.Current).CurrnetUser.NickName;
            }
            
        }
        public async void SetupQus()
        {
            answerList.Clear();
            AmericanQuestion american = await TriviaWebAPIProxy.CreateProxy().GetRandomQuestion();
            Question = american.QText;
            CurrnetCoAnswer = american.CorrectAnswer;

            answerList.Add(CurrnetCoAnswer);
            foreach (var item in american.OtherAnswers)
            {
                answerList.Add(item);
            }
            Shuffle(answerList);
            ChangeColor = Color.White;


        }
        public static void Shuffle(IList<string> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
       
        public ICommand PressCommand => new Command(refreshAnCheck);
        public event Action<Page> NavigateToPageEvent;
        
        public void AddQoutions()
        {
            Page page = new AddQustion();
            NavigateToPageEvent?.Invoke(page);
        }
        public async void refreshAnCheck()
        {
            bool con = false;
            if (CurrnetCoAnswer == CorectAnswer)
            {
                NumCorrectQus++;
                this.ChangeColor = Color.Green;

                if (NumCorrectQus >= 3)
                {
                    this.NumCorrectQus = 0;
                    AddQoutions();
                    
                }

            }
            else ChangeColor = Color.Red;
            if (!con)
            {
                SetupQus();
            }
        }
        public void check()
        {
            if (((App)App.Current).IsNew != false)
            {
                Isvisible = true;
                Show = false;
            }
            else
            {
                Isvisible = false;
                Show = true;
            }
        }
        public void Checkthree()
        {
            
                
                AddQoutions();
            Isvisible = false;
            Show = true;
                ((App)App.Current).IsNew = false;
            
        }
        public ICommand Logout => new Command(LogOut);
        public void LogOut()
        {
            ((App)App.Current).CurrnetUser = null;
            App.Current.MainPage = ((App)App.Current).login;
        }
        public bool Isvisible { get=>isvisble; set
            {
                if(value!=isvisble)
                {
                    isvisble = value;
                    OnPropertyChanged(nameof(Isvisible));
                }
            } }
        public bool Show { get=>show; set
            {
                if(show!=value)
                {
                    show = value;
                    OnPropertyChanged(nameof(Show));
                }
            } }
        private bool isvisble;
        private bool show;
        public ICommand EnterQues => new Command(Checkthree);
    }
}
