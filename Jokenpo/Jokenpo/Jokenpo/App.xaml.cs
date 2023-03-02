using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jokenpo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Jokenpo();
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
