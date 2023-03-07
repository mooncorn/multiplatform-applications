using System;
using MidtermExam.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MidtermExam
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new Master();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

