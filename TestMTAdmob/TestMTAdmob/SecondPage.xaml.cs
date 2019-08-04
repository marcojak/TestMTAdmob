using System;
using MarcTron.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestMTAdmob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();

            CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
            CrossMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialVideoAdLoaded;
            CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialVideoAdClosed;
            CrossMTAdmob.Current.OnInterstitialOpened += Current_OnInterstitialVideoOpened;

            CrossMTAdmob.Current.LoadRewardedVideo("ca-app-pub-3940256099942544/5224354917");
            CrossMTAdmob.Current.OnRewardedVideoAdLoaded += Current_OnRewardedVideoAdLoaded;
            CrossMTAdmob.Current.OnRewardedVideoAdClosed += Current_OnRewardedVideoAdClosed;
            CrossMTAdmob.Current.OnRewardedVideoAdLeftApplication += Current_OnRewardedVideoAdLeftApplication;
            CrossMTAdmob.Current.OnRewarded += Current_OnRewarded;
        }

        void ShowInterstitialAd(object sender, EventArgs e)
        {
            if (!CrossMTAdmob.Current.IsInterstitialLoaded())
            {
                DisplayAlert("Alert", "Interstitial ad not loaded", "OK");
                return;
            }
            CrossMTAdmob.Current.ShowInterstitial();
        }

        void ShowRewardedAd(object sender, EventArgs e)
        {
            if (!CrossMTAdmob.Current.IsRewardedVideoLoaded())
            {
                DisplayAlert("Alert", "Rewarded ad not loaded", "OK");
                return;
            }
            CrossMTAdmob.Current.ShowRewardedVideo();
        }

        private void Current_OnInterstitialVideoOpened(object sender, EventArgs e)
        {
            Console.WriteLine("1 - Current_OnInterstitialVideoOpened");
        }

        private void Current_OnInterstitialVideoAdClosed(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
            Console.WriteLine("2 - Current_OnInterstitialVideoAdClosed");
        }

        private void Current_OnInterstitialVideoAdLoaded(object sender, EventArgs e)
        {
            Console.WriteLine("3 - Current_OnInterstitialVideoAdLoaded");
        }

        private void Current_OnRewardedVideoAdLeftApplication(object sender, EventArgs e)
        {
            Console.WriteLine("1 - Current_OnRewardedVideoAdLeftApplication");
        }

        private void Current_OnRewardedVideoAdClosed(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadRewardedVideo("ca-app-pub-3940256099942544/5224354917");
            Console.WriteLine("2 - Current_OnRewardedVideoAdClosed");
        }

        private void Current_OnRewardedVideoAdLoaded(object sender, EventArgs e)
        {
            Console.WriteLine("3 - Current_OnRewardedVideoAdLoaded");
        }

        private void Current_OnRewarded(object sender, MTEventArgs e)
        {
            Console.WriteLine("4 - Current_OnRewarded");
        }
    }
}