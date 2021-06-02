using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using System.Security.Cryptography;
using System.ComponentModel;
namespace TriviaXamarinApp.ViewModels
{
    class StartPageCiewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged( string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Question { get=>qustion; set 
            { 
                if(value!=qustion)
                {
                    qustion = value;
                    OnPropertyChanged(nameof(Question));
                }
            } }
        public string qustion;
        public ObservableCollection<string> answerList  { get; set; }
        public int NumCorrectQus { get=>numco; set
            {
                if(value!=numco)
                {
                    numco = value;
                    OnPropertyChanged(nameof(NumCorrectQus));
                }
            } }
        private int numco;
        public Color chooseanswer { get =>colorchoos; set
            {
                if(colorchoos!=value)
                {
                    colorchoos = value;
                    OnPropertyChanged(nameof(chooseanswer));
                }
            } }
        private Color colorchoos;
        public Color AnswerColor { get; set; }
        private Color answercolor;
        public string CorectAnswer { get=>corectAnswer; set
            {
                if (value!=corectAnswer)
                {
                    corectAnswer = value;
                    OnPropertyChanged(nameof(CorectAnswer));
                }
                 } }
        string corectAnswer;
        private string CurrnetCoAnswer;
        public ICommand selectionComamd => new Command(ChangeColor);
        public ICommand PressCommand => new Command(refreshAnCheck);
        public StartPageCiewModel()
        {
            answerList = new ObservableCollection<string>();
            numco = 0;
            chooseanswer = new Color();
            chooseanswer = Color.White;
            colorchoos = new Color();
            colorchoos = Color.White;
            answercolor = new Color();
            answercolor = Color.White;
            AnswerColor = new Color();
            AnswerColor = Color.White;
            SetupQus();
        }
        public async void SetupQus()
        {
            AmericanQuestion american= await TriviaWebAPIProxy.CreateProxy().GetRandomQuestion();
            Question = american.QText;
            CurrnetCoAnswer = american.CorrectAnswer;
            answerList.Add(corectAnswer);
            foreach (var item in american.OtherAnswers)
            {
                answerList.Add(item);
            }
            Shuffle(answerList);
          

        }
        public static void Shuffle( IList<string> list)
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
        void ChangeColor()
        {
            chooseanswer = Color.Blue;
        }
        public async void refreshAnCheck()
        {
            if(CurrnetCoAnswer==CorectAnswer)
            {
                NumCorrectQus++;
                AnswerColor = Color.Green;
                if(NumCorrectQus==3)
                {
                    //פתיחת מסך חדש
                }
                else
                {
                    //await
                    Task t = new Task(SetupQus);
                    t.Wait(2500);
                }
            }
        }
    }
}
