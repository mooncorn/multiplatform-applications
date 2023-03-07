using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MidtermExam.Pages
{	
	public partial class Question3 : ContentPage
	{	
		public Question3 ()
		{
			InitializeComponent ();
		}

        void sliderHeight_ValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            lblHeightValue.Text = sliderHeight.Value.ToString("0.00") + "cm";
        }

        void sliderWeight_ValueChanged_1(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            lblWeightValue.Text = sliderWeight.Value.ToString("0.0") + "kg";
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var height = Double.Parse(sliderHeight.Value.ToString());
            var weight = Double.Parse(sliderWeight.Value.ToString());
            var heightInMeters = height / 100;
            var bmi = weight / (heightInMeters * heightInMeters);
            lblBmiValue.Text = bmi.ToString("0.00");
        }
    }
}

