using System;
using System.Collections.Generic;
using TaskAppFinal.API;
using TaskAppFinal.Services;
using Xamarin.Forms;

namespace TaskAppFinal.Pages
{	
	public partial class SignUp : ContentPage
	{	
		public SignUp ()
		{
			InitializeComponent ();
		}

        async void Button_Clicked(Object sender, EventArgs e)
        {
			try
			{
				await AppState.GetInstance().ApiClient.SignUp(Name.Text, Email.Text, Password.Text);
				Message.Text = "Signed up successfully";
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

