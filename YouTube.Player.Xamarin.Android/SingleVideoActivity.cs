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
using YouTube.Player.Xamarin.Constants;
using YouTube.Player.Xamarin.Models;
using YouTube.Player.Xamarin.ViewModels;

namespace YouTube.Player.Xamarin.Droid
{
    [Activity(Label = "SingleVideoActivity")]
    public class SingleVideoActivity : YouTubeBaseActivity, IYouTubePlayerOnInitializedListener
    {
        YoutubeItem youtubeItem;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.SingleActivityLayout);
            // Create your application here
            var txtTitleHeader = FindViewById<TextView>(Resource.Id.txtVideoTitle);
            var youtubeView = FindViewById<YouTubePlayerView>(Resource.Id.youtube_view);
            youtubeItem = JsonConvert.DeserializeObject<YoutubeItem>(Intent.GetStringExtra("SelectedVideo"));

            txtTitleHeader.Text = youtubeItem.Title;

            youtubeView.Initialize(Configs.ApiKey, this);
        }
        public void OnInitializationFailure(IYouTubePlayerProvider p0, YouTubeInitializationResult errorReason)
        {
            if (errorReason.IsUserRecoverableError)
            {
                errorReason.GetErrorDialog(this, 1).Show();
            }
            else
            {
                //String errorMessage = String.Format(GetString(Resource.String.error_player), errorReason.ToString());
                //Toast.MakeText(this, errorReason.ToString(), ToastLength.Long).Show();

                new AlertDialog.Builder(MainActivity.Instance)
                .SetTitle("Error playing video")
                .SetMessage("Youtube app must be installed in yout device to use this feature.")
                .Show();
            }
        }

        public void OnInitializationSuccess(IYouTubePlayerProvider p0, IYouTubePlayer player, bool wasRestored)
        {
            if (!wasRestored)
            {
                player.CueVideo(youtubeItem.VideoId);
                player.Play();
            }
            
        }

        
    }
}