using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : Xamarin.Forms.TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            this.Children.Add(new MainMenu()
            { Title="Main Page"});
            Page p = new MyQustions()
            {
                Title = "My Qustions",
                IconImageSource = "https://i.pinimg.com/736x/3f/94/70/3f9470b34a8e3f526dbdb022f9f19cf7.jpg"
            };
            
            this.Children.Add(new NavigationPage(p) { Title= "My Qustions" });
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}