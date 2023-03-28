
using System;
using System.Collections.Generic;
using TaskAppFinal.Models;
using TaskAppFinal.Services;
using Xamarin.Forms;

namespace TaskAppFinal.Pages
{	
	public partial class DeleteTask : ContentPage
	{
		private AssignedTask _task;

		public DeleteTask (AssignedTask task)
		{
			InitializeComponent ();
			_task = task;
            Description.Text = task.Description;
		}

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await AppState.GetInstance().ApiClient.DeleteTask(_task.TaskUid);
                Message.Text = "Task deleted successfully";
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

