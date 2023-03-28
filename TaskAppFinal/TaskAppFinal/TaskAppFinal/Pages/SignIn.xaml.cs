using System;
using System.Collections.Generic;
using TaskAppFinal.API;
using TaskAppFinal.Models;
using TaskAppFinal.Services;
using Xamarin.Forms;

namespace TaskAppFinal.Pages
{	
	public partial class SignIn : ContentPage
	{	
		public SignIn ()
		{
			InitializeComponent ();
		}

        async void Button_Clicked(Object sender, EventArgs e)
        {
            var state = AppState.GetInstance();

            try
            {
                state.User = await state.ApiClient.SignIn(Email.Text, Password.Text);
                Message.Text = "Signed in successfully";
                Message.TextColor = Color.Green;
            }
            catch (Exception ex)
            {
                Message.Text = ex.Message;
                Message.TextColor = Color.Red;
            }
        }
    }
}

