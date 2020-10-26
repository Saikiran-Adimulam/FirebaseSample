using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Hostella.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthService))]
namespace Hostella.Droid
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        public string GetUserId()
        {
            try
            {
                return FirebaseAuth.Instance.CurrentUser.Uid;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                var errorMessage = e.Message ?? "Failed to login";
                await Application.Current.MainPage.DisplayAlert("Error", errorMessage, "Ok");
                return "";
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                var errorMessage = e.Message ?? "Failed to login";
                await Application.Current.MainPage.DisplayAlert("Error", errorMessage, "Ok");
                return "";
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to login", "Ok");
                return "";
            }
        }

        public void SignOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
            }
            catch (Exception e)
            {

            }
        }

        public async Task<string> SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var signUpTask = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

                return signUpTask.User.Uid;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                var errorMessage = ex.Reason ?? "Failed to register";
                await Application.Current.MainPage.DisplayAlert("Error", errorMessage, "Ok");
                return "";
            }
            catch (FirebaseAuthUserCollisionException ex)
            {
                var errorMessage = ex.Message ?? "Failed to register";
                await Application.Current.MainPage.DisplayAlert("Error", errorMessage, "Ok");
                return "";
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to register", "Ok");
                return "";
            }
        }
    }
}
