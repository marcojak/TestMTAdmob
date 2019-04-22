using System;
using System.Collections.Generic;
using MarcTron.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestMTAdmob
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Here you can add your test devices if needed
            //CrossMTAdmob.Current.TestDevices = new List<string>() {"yourtestdeviceID"};

            MainPage = new MainPage();
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
