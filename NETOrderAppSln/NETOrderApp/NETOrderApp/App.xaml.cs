using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NETOrderApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Mainpage();
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
