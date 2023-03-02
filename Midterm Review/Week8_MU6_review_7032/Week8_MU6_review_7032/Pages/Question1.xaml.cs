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
    public partial class Question1 : ContentPage
    {
        List<string> myList = new List<string>();
        public Question1()
        {
            InitializeComponent();
            myList.Add("renan@email.com");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (myList.Contains(txtEmail.Text))
            {
                lblResult.Text = "USER FOUND!";
                lblResult.TextColor = Color.Green;
            }
            else
            {
                lblResult.Text = "USER NOT FOUND!";
                lblResult.TextColor = Color.Red;
            }
        } 
    }
}