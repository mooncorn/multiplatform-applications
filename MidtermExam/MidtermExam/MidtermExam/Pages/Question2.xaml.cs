using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MidtermExam.Pages
{	
	public partial class Question2 : ContentPage
	{
		private Dictionary<string, string> dict;

		public Question2 ()
		{
			InitializeComponent();
			dict = new Dictionary<string, string>
			{
				{ "user1@hotmail.com", "user123" },
				{ "user2@hotmail.com", "user321" }
			};
		}

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
			if (!dict.ContainsKey(txtEmail.Text))
			{
				lblResult.Text = "EMAIL DOES NOT EXIST";
				lblResult.TextColor = Color.Red;
				return;
			}

			if (dict[txtEmail.Text] != txtPassword.Text)
			{
                lblResult.Text = "INVALID PASSWORD";
                lblResult.TextColor = Color.Red;
                return;
            }

            lblResult.Text = "YOU ARE LOGGED";
            lblResult.TextColor = Color.Green;
        }
    }
}

