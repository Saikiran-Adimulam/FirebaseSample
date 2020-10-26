using System;
using System.Threading.Tasks;

namespace Hostella
{
    public interface IFirebaseAuthService
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> SignUpWithEmailPassword(string email, string password);
        void SignOut();
        string GetUserId();
    }
}
