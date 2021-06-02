using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbed : Xamarin.Forms.TabbedPage
    {
        public MainTabbed()
        {
            InitializeComponent();
        }
        public void CreateTabes()
        {
            On<Windows>().SetHeaderIconsEnabled(true);
            On<Windows>().SetHeaderIconsSize(new Size(48, 48));

            Xamarin.Forms.Page mainMenu = new NavigationPage(new MainMenu());
            mainMenu.Title = "Main";
            
            Xamarin.Forms.Page MyQustions = new NavigationPage();
            MyQustions.Title = "My Qustions";
            

            this.Children.Add(MyQustions);
            this.Children.Add(MyQustions);
        }
    }
}