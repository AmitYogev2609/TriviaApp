using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Models;
namespace TriviaXamarinApp.ViewModels
{
    class StartPageCiewModel
    {
        public string Question { get; set; }
        public ObservableCollection<string> MyProperty { get; set; }
        public string  NumCorrectQus { get; set; }
        private int indexcorect;
        public StartPageCiewModel()
        {
            SetupQus();
        }
        public async void SetupQus()
        {
            AmericanQuestion american;
        }
        public void refreshAnCheck(int index)
        {

        }
    }
}
