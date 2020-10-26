using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hostella
{
    public partial class App : Application
    {
        public static readonly NavigationPage Navigation = new NavigationPage();

        public App()
        {
            InitializeComponent();

            MainPage = Navigation;

            Navigation.PushAsync(new LoginPage());
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
