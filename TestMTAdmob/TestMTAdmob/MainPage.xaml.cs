using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MarcTron.Plugin;
using Xamarin.Forms;

namespace TestMTAdmob
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<List<string>> MtEvents { get; set; }

        public MainPage()
        {
            InitializeComponent();

            //The banner inside the XAML but if you prefer you can load it here programmatically 


            CrossMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
            CrossMTAdmob.Current.OnInterstitialOpened += Current_OnInterstitialOpened;
            CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;

            CrossMTAdmob.Current.OnRewardedVideoAdLoaded += Current_OnRewardedVideoAdLoaded;
            CrossMTAdmob.Current.OnRewardedVideoAdClosed += Current_OnRewardedVideoAdClosed;
            CrossMTAdmob.Current.OnRewardedVideoAdFailedToLoad += Current_OnRewardedVideoAdFailedToLoad;
            CrossMTAdmob.Current.OnRewardedVideoAdLeftApplication += Current_OnRewardedVideoAdLeftApplication;
            CrossMTAdmob.Current.OnRewardedVideoStarted += Current_OnRewardedVideoStarted;
            CrossMTAdmob.Current.OnRewarded += Current_OnRewarded;
        }

        private void Current_OnRewarded(object sender, MTEventArgs e)
        {
        }

        private void Current_OnRewardedVideoStarted(object sender, EventArgs e)
        {
        }

        private void Current_OnRewardedVideoAdLeftApplication(object sender, EventArgs e)
        {
        }

        private void Current_OnRewardedVideoAdFailedToLoad(object sender, MTEventArgs e)
        {
        }

        private void Current_OnRewardedVideoAdClosed(object sender, EventArgs e)
        {
        }

        private void Current_OnRewardedVideoAdLoaded(object sender, EventArgs e)
        {
        }

        private void Current_OnInterstitialClosed(object sender, EventArgs e)
        {
        }

        private void Current_OnInterstitialOpened(object sender, EventArgs e)
        {
        }

        private void Current_OnInterstitialLoaded(object sender, EventArgs e)
        {
        }

        private void IsInterstitialLoaded(object sender, EventArgs e)
        {
            bool isLoaded = CrossMTAdmob.Current.IsInterstitialLoaded();
        }

        private void LoadInterstitial(object sender, EventArgs e)
        {
            //This is a Test ID Interstitial, you should replace it with yours
            CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
        }

        private void ShowInterstitial(object sender, EventArgs e)
        {
            //You must load an interstitial before showing it
            CrossMTAdmob.Current.ShowInterstitial();
        }

        private void IsRewardedVideoLoaded(object sender, EventArgs e)
        {
            bool isLoaded = CrossMTAdmob.Current.IsRewardedVideoLoaded();
        }

        private void LoadRewardedVideo(object sender, EventArgs e)
        {
            //This is a Test ID Rewarded Video, you should replace it with yours
            CrossMTAdmob.Current.LoadRewardedVideo("ca-app-pub-3940256099942544/5224354917");
        }

        private void ShowRewardedVideo(object sender, EventArgs e)
        {
            //You must load a Rewarded Video before showing it
            CrossMTAdmob.Current.ShowRewardedVideo();
        }
    }
}
