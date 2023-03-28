using System;
using System.Collections.Generic;
using TaskAppFinal.Models;
using TaskAppFinal.Services;
using Xamarin.Forms;

namespace TaskAppFinal.Pages
{	
	public partial class GetTasksCreatedBy : ContentPage
	{	
		public GetTasksCreatedBy ()
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
                var tasks = await AppState.GetInstance().ApiClient.GetTasksCreatedBy();
                taskList.ItemsSource = tasks;
            }
            catch (Exception e)
            {
                Message.Text = e.Message;
            }
        }

        async void taskList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var task = (AssignedTask)e.SelectedItem;
            await Navigation.PushAsync(new DeleteTask(task));
        }
    }
}

