using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Hostella
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void HandleLoginClick(System.Object sender, System.EventArgs e)
        {
            var authService = DependencyService.Get<IFirebaseAuthService>();
            string userName = usernameEntry.Text;
            string password = passwordEntry.Text;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var uid = await authService.LoginWithEmailPassword(userName, password);
                if (uid == "")
                {
                }
                else
                {
                    App.Navigation.PushAsync(new MainPage());
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Warning", "Username and password mandatory", "Ok");
            }
        }

        async void HandleRegisterClick(System.Object sender, System.EventArgs e)
        {
            var authService = DependencyService.Get<IFirebaseAuthService>();
            string userName = usernameEntry.Text;
            string password = passwordEntry.Text;
            if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var uid = await authService.SignUpWithEmailPassword(userName, password);
                if(uid == "")
                {
                    Application.Current.MainPage.DisplayAlert("Warning", "Failed", "Ok");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Warning", "Successful", "Ok");
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Warning", "Username and password mandatory", "Ok");
            }
        }
    }
}
