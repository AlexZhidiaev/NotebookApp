using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotebookApp
{
    public partial class App : Application
    {
        static string login;
        public static void setLogin(string log) {
            login = log;
        }
        public static string getLogin() {
            return login;
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
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
