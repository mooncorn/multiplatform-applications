using System;
using Week8_MU6_review_7032.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week8_MU6_review_7032
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Master();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
