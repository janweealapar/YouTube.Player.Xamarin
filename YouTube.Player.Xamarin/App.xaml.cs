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
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
