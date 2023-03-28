using System;
using System.Collections.Generic;
using TaskAppFinal.Services;
using Xamarin.Forms;
namespace TaskAppFinal.Pages
{	
	public partial class CreateTask : ContentPage
	{	
		public CreateTask ()
		{
			InitializeComponent ();
		}

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await AppState.GetInstance().ApiClient.CreateTask(Description.Text, AssignedToUid.Text);
                Message.Text = "Task created successfully";
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

