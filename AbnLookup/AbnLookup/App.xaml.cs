using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AbnLookup
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // CROSS SETTINGS
            //CrossSettings.Current.AddOrUpdateValue<string>("SaveLatestSearches", "N");
            //string valuex = CrossSettings.Current.GetValueOrDefault<string>("SaveLatestSearches", "N");

            MainPage = new AbnLookup.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
