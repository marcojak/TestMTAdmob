using MarcTron.Plugin;
using Xamarin.Forms;

namespace TestMTAdmob
{
    public partial class App : Application
    {
        private bool isAndroid = true;

        public App()
        {
            InitializeComponent();

            CrossMTAdmob.Current.AdsId = isAndroid ? "ca-app-pub-3940256099942544/6300978111" : "ca-app-pub-3940256099942544/2934735716"; 
            
            //You can add here the id of your test devices!
            //CrossMTAdmob.Current.TestDevices = new List<string>() {  };

            MainPage = new NavigationPage(new MainPage());
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
