using System;
using System.Collections.Generic;
using TaskAppFinal.Services;
using Xamarin.Forms;

namespace TaskAppFinal.Pages
{	
	public partial class AllUsers : ContentPage
	{	
		public AllUsers ()
		{
			InitializeComponent ();
			fetchUsers();
		}

		private async void fetchUsers()
		{
			try
			{
				var users = await AppState.GetInstance().ApiClient.GetAllUsers();
				userList.ItemsSource = users;
			}
			catch (Exception e)
			{
				Message.Text = e.Message;
			}
		}
	}
}

