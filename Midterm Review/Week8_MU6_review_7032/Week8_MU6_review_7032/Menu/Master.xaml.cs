using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8_MU6_review_7032.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week8_MU6_review_7032.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : FlyoutPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new Question1();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Detail = new Question2();
        }
    }
}