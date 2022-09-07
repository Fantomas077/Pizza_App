using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var navigationPage = new NavigationPage(new MainPage());
            MainPage = navigationPage;
            navigationPage.BarBackgroundColor = Color.FromHex("#1abbd4");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
