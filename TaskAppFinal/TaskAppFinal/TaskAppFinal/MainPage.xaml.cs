using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAppFinal.Services;
using Xamarin.Forms;

namespace TaskAppFinal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            login(); // auto login
        }

        private async void login()
        {
            var user = await AppState.GetInstance().ApiClient.SignIn("dave@gmail.com", "admin");
            Name.Text = user.Name;
            Email.Text = user.Email;
            Uid.Text = user.UID;
            Token.Text = AppState.GetInstance().ApiClient.Token;
        }
    }
}

