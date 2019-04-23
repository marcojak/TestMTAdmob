using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MarcTron.Plugin;
using MarcTron.Plugin.Controls;
using Xamarin.Forms;

namespace TestMTAdmob
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> MtEvents { get; set; } = new ObservableCollection<string>();

        public MainPage()
        {
            InitializeComponent();
            MtEvents.CollectionChanged += MtEvents_CollectionChanged;

            //REMEMBER ALWAYS TO INITIALIZE ADMOB IN YOUR ANDROID AND IOS PROJECTS (Like in the Android and iOS Projects here)
            //For Android REMEMBER to add the next 2 lines in your android Manifest (You can check the manifest inside the android project in this solution):

            //<meta-data android:name="com.google.android.gms.version" android:value="@integer/google_play_services_version"/>
            //<activity android:name="com.google.android.gms.ads.AdActivity" android:configChanges="keyboard|keyboardHidden|orientation|screenLayout|uiMode|screenSize|smallestScreenSize" android:theme="@android:style/Theme.Translucent" />

            //The banner inside the XAML but if you prefer you can load it here programmatically using the code below. Remember to add it to your view
            //AdView myAds = new AdView {AdsId = "ca-app-pub-3940256099942544/6300978111", PersonalizedAds = true};

            //Now we set the events (just if we want)

            //Events for banners
            myAds.AdsClosed += MyAds_AdsClosed;
            myAds.AdsOpened += MyAds_AdsOpened;

            //Events for Interstitials
            CrossMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
            CrossMTAdmob.Current.OnInterstitialOpened += Current_OnInterstitialOpened;
            CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;

            //Events for Rewarded Videos
            CrossMTAdmob.Current.OnRewardedVideoAdLoaded += Current_OnRewardedVideoAdLoaded;
            CrossMTAdmob.Current.OnRewardedVideoAdClosed += Current_OnRewardedVideoAdClosed;
            CrossMTAdmob.Current.OnRewardedVideoAdFailedToLoad += Current_OnRewardedVideoAdFailedToLoad;
            CrossMTAdmob.Current.OnRewardedVideoAdLeftApplication += Current_OnRewardedVideoAdLeftApplication;
            CrossMTAdmob.Current.OnRewardedVideoStarted += Current_OnRewardedVideoStarted;
            CrossMTAdmob.Current.OnRewarded += Current_OnRewarded;
        }

        private void MyAds_AdsOpened(object sender, EventArgs e)
        {
            MtEvents.Add("MyAds_AdsOpened");
        }

        private void MyAds_AdsClosed(object sender, EventArgs e)
        {
            MtEvents.Add("MyAds_AdsClosed");
        }

        private void MtEvents_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (MtEvents.Count > 0)
                MylistView.ScrollTo(MtEvents[MtEvents.Count - 1], ScrollToPosition.End, true);
        }

        private void Current_OnRewarded(object sender, MTEventArgs e)
        {
            MtEvents.Add($"On Rewarded: {e.RewardType} - {e.RewardAmount}");
        }

        private void Current_OnRewardedVideoStarted(object sender, EventArgs e)
        {
            MtEvents.Add("Rewarded Video started");
        }

        private void Current_OnRewardedVideoAdLeftApplication(object sender, EventArgs e)
        {
            MtEvents.Add("Rewarded Video left application");
        }

        private void Current_OnRewardedVideoAdFailedToLoad(object sender, MTEventArgs e)
        {
            MtEvents.Add("Rewarded Video Ad failed to load");
        }

        private void Current_OnRewardedVideoAdClosed(object sender, EventArgs e)
        {
            MtEvents.Add("OnRewardedVideoAdClosed");
        }

        private void Current_OnRewardedVideoAdLoaded(object sender, EventArgs e)
        {
            MtEvents.Add("Current_OnRewardedVideoAdLoaded");
        }

        private void Current_OnInterstitialClosed(object sender, EventArgs e)
        {
            MtEvents.Add("Current_OnInterstitialClosed");
        }

        private void Current_OnInterstitialOpened(object sender, EventArgs e)
        {
            MtEvents.Add("Current_OnInterstitialOpened");
        }

        private void Current_OnInterstitialLoaded(object sender, EventArgs e)
        {
            MtEvents.Add("Current_OnInterstitialLoaded");
        }

        private void IsInterstitialLoaded(object sender, EventArgs e)
        {
            bool isLoaded = CrossMTAdmob.Current.IsInterstitialLoaded();
            MtEvents.Add($"IsInterstitialLoaded: {isLoaded}");
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
            MtEvents.Add($"IsRewardedVideoLoaded: {isLoaded}");
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
