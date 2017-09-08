using Search_POC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Xamarin.Forms;

namespace Search_POC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MobileCenter.Start("android=aa692b7f-6ccc-4c32-87b3-b939703ffa73;" 
                //+
                //   "uwp={Your UWP App secret here};" +
                //   "ios={Your iOS App secret here}"
                   ,typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
