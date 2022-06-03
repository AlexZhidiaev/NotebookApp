using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotebookApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UsersFirebase _userRepository = new UsersFirebase();
        public ICommand TapCommand => new Command(async () => await Navigation.PushModalAsync(new RegisterPage()));

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            //InitializeComponent();
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            if (String.IsNullOrEmpty(email))
            {
                await DisplayAlert("Warning", "Enter your email", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(password))
            {
                await DisplayAlert("Warning", "Enter your password", "Ok");
                return;
            }
            string token = await _userRepository.SignIn(email, password);
            if (!string.IsNullOrEmpty(token))
            {
                App.setLogin(email);
                Preferences.Set("token", token);
                Preferences.Set("userEmail", email);
                await Navigation.PushAsync(new TodoListPage());
            }
            else
            {
                await DisplayAlert("Sign In", "Sign in failed", "ok");
            }

        }
        private async void RegisterTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}