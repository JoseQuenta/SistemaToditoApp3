using SistemaToditoApp3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaToditoApp3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new MenuPrincipal());
            //MainPage = new NavigationPage(new Login());
            MainPage = new Login();
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
