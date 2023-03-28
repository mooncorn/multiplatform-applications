using System;
using System.Collections.Generic;
using TaskAppFinal.Pages;
using Xamarin.Forms;

namespace TaskAppFinal.Menu
{	
	public partial class Master : FlyoutPage
	{	
		public Master ()
		{
			InitializeComponent ();
            Button_Clicked_6(this, null);
		}

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new SignUp());
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new SignIn());
        }

        void Button_Clicked_2(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new AllUsers());
        }

        void Button_Clicked_3(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new CreateTask());
        }

        void Button_Clicked_4(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new GetTasksCreatedBy());
        }

        void Button_Clicked_5(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new GetTasksAssignedTo());
        }

        void Button_Clicked_6(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new MainPage());
        }
    }
}

