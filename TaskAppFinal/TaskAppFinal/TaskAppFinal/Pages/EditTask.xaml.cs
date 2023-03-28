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

		public EditTask(AssignedTask task)
		{
			InitializeComponent ();
            _task = task;
            TaskUid.Text = task.TaskUid;
			Description.Text = task.Description;
            AssignedToName.Text = task.AssignedToName;
            AssignedToUid.Text = task.AssignedToUid;
            CreatedByName.Text = task.CreatedByName;
            CreatedByUid.Text = task.CreatedByUid; 
            SwitchDone.IsToggled = Boolean.Parse(task.Done);
		}

        async void SwitchDone_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (e.Value == Boolean.Parse(_task.Done)) return;

            try
            {
                await AppState.GetInstance().ApiClient.UpdateTask(_task.TaskUid, e.Value);
                _task.Done = e.Value.ToString();
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

