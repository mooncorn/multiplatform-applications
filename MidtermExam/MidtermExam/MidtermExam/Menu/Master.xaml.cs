using System;
using System.Collections.Generic;
using MidtermExam.Pages;
using Xamarin.Forms;

namespace MidtermExam.Menu
{	
	public partial class Master : FlyoutPage
	{	
		public Master ()
		{
			InitializeComponent ();
		}

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Detail = new Question1();
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            Detail = new Question2();
        }

        void Button_Clicked_2(System.Object sender, System.EventArgs e)
        {
            Detail = new Question3();
        }
    }
}

