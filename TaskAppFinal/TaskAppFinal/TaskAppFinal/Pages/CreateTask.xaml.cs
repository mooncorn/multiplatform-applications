using System;
using System.Collections.Generic;
using TaskAppFinal.Models;
using TaskAppFinal.Services;
using Xamarin.Forms;
namespace TaskAppFinal.Pages
{	
	public partial class CreateTask : ContentPage
	{	
		public CreateTask ()
		{
			InitializeComponent ();
            fetchUsers();
		}

        private async void fetchUsers()
        {
            try
            {
                var users = await AppState.GetInstance().ApiClient.GetAllUsers();
                AssignedToUser.ItemsSource = users;
            }
            catch (Exception e)
            {
                Message.Text = e.Message;
            }
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var user = (User)AssignedToUser.SelectedItem;

            if (user == null)
            {
                Message.Text = "Assigned to user field is required";
                Message.TextColor = Color.Red;
                return;
            }

            try
            {
                await AppState.GetInstance().ApiClient.CreateTask(Description.Text, user.UID);
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

