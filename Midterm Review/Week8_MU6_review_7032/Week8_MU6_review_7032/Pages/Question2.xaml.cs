using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week8_MU6_review_7032.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Question2 : ContentPage
    {
        public Question2()
        {
            InitializeComponent();
        }

        private void gradeMid_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblMid.Text = e.NewValue.ToString();
        }

        private void gradeProject_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblProject.Text = e.NewValue.ToString();
        }

        private void gradeFinal_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblFinal.Text = e.NewValue.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            double avg = (gradeMid.Value + gradeProject.Value + gradeFinal.Value) / 3;
            lblGrade.Text = avg.ToString();
            lblStatus.Text = avg >= 60 ? "Passed" : "Failed";
            pbGrade.ProgressTo(avg / 100, 3000, Easing.Linear);
            //if(avg >= 60)
            //{
            //    lblStatus.Text = "Passed";
            //}
            //else
            //{
            //    lblStatus.Text = "Failed";
            //}
        }
    }
}