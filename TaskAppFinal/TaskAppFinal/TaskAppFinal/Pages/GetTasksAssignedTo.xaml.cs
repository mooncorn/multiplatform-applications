using System;
using System.Collections.Generic;
using TaskAppFinal.Models;
using TaskAppFinal.Services;
using Xamarin.Forms;

namespace TaskAppFinal.Pages
{	
	public partial class GetTasksAssignedTo : ContentPage
	{	
		public GetTasksAssignedTo ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            fetchTasks();
        }

        private async void fetchTasks()
        {
            try
            {
                var tasks = await AppState.GetInstance().ApiClient.GetTasksAssignedTo();
                taskList.ItemsSource = tasks;
            }
            catch (Exception e)
            {
                Message.Text = e.Message;
            }
        }

        async void taskList_ItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            var task = (AssignedTask)e.SelectedItem;
            await Navigation.PushAsync(new EditTask(task));
        }
    }
}

