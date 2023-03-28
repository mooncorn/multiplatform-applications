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
            SwitchDone.IsToggled = Boolean.Parse(task.Done);
		}

        async void SwitchDone_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (SwitchDone.IsToggled == Boolean.Parse(_task.Done)) return;

            try
            {
                await AppState.GetInstance().ApiClient.UpdateTask(_task.TaskUid, SwitchDone.IsToggled);
                _task.Done = SwitchDone.IsToggled.ToString();
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

