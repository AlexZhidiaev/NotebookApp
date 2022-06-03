using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public class UsersFirebase
    {
        string webAPIKey = "AIzaSyC0b_0Euhcgpq51ZBTgsBYd7sCh9EeYM5Q";
        FirebaseAuthProvider authProvider;

        public UsersFirebase() {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));
        }

        public async Task<bool> Register(string email, string password)
        {

            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;
            }
            return false;
        }

        public async Task<string> SignIn(string email, string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";
        }

    }
}
