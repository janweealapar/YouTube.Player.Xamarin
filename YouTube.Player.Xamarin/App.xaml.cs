using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YouTube.Player.Xamarin.Interfaces;
using YouTube.Player.Xamarin.Services;
using YouTube.Player.Xamarin.Views;

namespace YouTube.Player.Xamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new YoutubeViewPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=6eff74f0-dec4-4e5a-99e7-fdac02342c9d;" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
