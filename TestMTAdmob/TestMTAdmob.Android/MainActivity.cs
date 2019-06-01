using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.Runtime;
using Android.OS;

namespace TestMTAdmob.Droid
{
    [Activity(Label = "TestMTAdmob", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            // Sample AdMob app ID: ca-app-pub-3940256099942544~3347511713
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-3940256099942544~3347511713");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            //This is a test Id: ca-app-pub-3940256099942544~3347511713
            //Remember to replace it with yours
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-3940256099942544~3347511713");
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}