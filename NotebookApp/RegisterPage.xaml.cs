using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotebookApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        UsersFirebase _userRepository = new UsersFirebase();
        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            string email = TxtLogin.Text;
            string password = TxtPassword.Text;
            string confirmPassword = TxtConfirmPass.Text;

            if (String.IsNullOrEmpty(email))
            {
                await DisplayAlert("Warning", "Type email", "Ok");
                return;
            }
            if (password.Length < 6)
            {
                await DisplayAlert("Warning", "Password should be 6 digit.", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(password))
            {
                await DisplayAlert("Warning", "Type password", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(confirmPassword))
            {
                await DisplayAlert("Warning", "Type Confirm password", "Ok");
                return;
            }
            if (password != confirmPassword)
            {
                await DisplayAlert("Warning", "Password not match.", "Ok");
                return;
            }

            bool isSave = await _userRepository.Register(email,password);
            if (isSave)
            {
                await DisplayAlert("Register user", "Registration completed", "Ok");
                await Navigation.PopModalAsync();
            }
            else {

            }
        }

        public RegisterPage()
        {
            InitializeComponent();
        }
    }
}