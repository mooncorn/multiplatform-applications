using System;
using System.Collections.Generic;
using TaskAppFinal.Models;
using TaskAppFinal.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TaskAppFinal.Pages
{	
	public partial class EditTask : ContentPage
	{
        private AssignedTask _task;

		public EditTask (AssignedTask task)
		{
			InitializeComponent ();
            _task = task;
			Description.Text = task.Description;
			Done.IsChecked = Boolean.Parse(task.Done);
		}

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await AppState.GetInstance().ApiClient.UpdateTask(_task.TaskUid, Done.IsChecked);
                Message.Text = "Task updated successfully";
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

