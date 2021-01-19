using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTube.Player.Xamarin.Interfaces;
using YouTube.Player.Xamarin.Models;

[assembly: Xamarin.Forms.Dependency(typeof(YouTube.Player.Xamarin.Droid.LaunchActivity))]
namespace YouTube.Player.Xamarin.Droid
{
    public class LaunchActivity : ILaunchActivity
    {
        public void LaunchSingleVideo(YoutubeItem item)
        {
            var intent = new Intent(MainActivity.Instance, typeof(SingleVideoActivity));
            intent.PutExtra("SelectedVideo", JsonConvert.SerializeObject(
                new YoutubeItem { 
                    VideoId = item.VideoId,
                    Title = item.Title
            }));

            MainActivity.Instance.StartActivity(intent);
            MainActivity.Instance.OverridePendingTransition(
                Android.Resource.Animation.FadeIn,
                Android.Resource.Animation.FadeOut);
        }
    }
}