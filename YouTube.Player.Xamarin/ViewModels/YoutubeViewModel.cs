using Android.Content;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YouTube.Player.Xamarin.Constants;
using YouTube.Player.Xamarin.Interfaces;
using YouTube.Player.Xamarin.Models;

namespace YouTube.Player.Xamarin.ViewModels
{
    public class YoutubeViewModel : INotifyPropertyChanged
    {
        private List<YoutubeItem> _youtubeItems;
        public List<YoutubeItem> YoutubeItems
        {
            get { return _youtubeItems; }
            set
            {
                _youtubeItems = value;
                OnPropertyChanged();
            }
        }
        public YoutubeViewModel()
        {
            ImageTappedCommand = new Command<YoutubeItem>((item) => ImageTapped(item));
            InitDataAsync();
        }

        public async Task InitDataAsync()
        {

            var videoIds = await GetVideoIdsFromChannelAsync();

            //var videoIds = await GetVideoIdsFromPlaylistAsync();
        }

        private async Task<List<string>> GetVideoIdsFromChannelAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Configs.apiUrlForChannel);

            var videoIds = new List<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    videoIds.Add(item.Value<JObject>("id")?.Value<string>("videoId"));
                }

                YoutubeItems = await GetVideosDetailsAsync(videoIds);
            }
            catch (Exception exception)
            {
            }

            return videoIds;
        }

        private async Task<List<string>> GetVideoIdsFromPlaylistAsync()
        {

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Configs.apiUrlForPlaylist);

            var videoIds = new List<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    videoIds.Add(item.Value<JObject>("contentDetails")?.Value<string>("videoId"));
                };

                YoutubeItems = await GetVideosDetailsAsync(videoIds);
            }
            catch (Exception exception)
            {
            }

            return videoIds;
        }

        private async Task<List<YoutubeItem>> GetVideosDetailsAsync(List<string> videoIds)
        {

            var videoIdsString = "";
            foreach (var s in videoIds)
            {
                videoIdsString += s + ",";
            }

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(string.Format(Configs.apiUrlForVideosDetails, videoIdsString));

            var youtubeItems = new List<YoutubeItem>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    var snippet = item.Value<JObject>("snippet");
                    var statistics = item.Value<JObject>("statistics");

                    var youtubeItem = new YoutubeItem
                    {
                        Title = snippet.Value<string>("title"),
                        Description = snippet.Value<string>("description"),
                        ChannelTitle = snippet.Value<string>("channelTitle"),
                        PublishedAt = snippet.Value<DateTime>("publishedAt"),
                        VideoId = item?.Value<string>("id"),
                        DefaultThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("default")?.Value<string>("url"),
                        MediumThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("medium")?.Value<string>("url"),
                        HighThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("high")?.Value<string>("url"),
                        StandardThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("standard")?.Value<string>("url"),
                        MaxResThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("maxres")?.Value<string>("url"),

                        ViewCount = statistics?.Value<int>("viewCount"),
                        LikeCount = statistics?.Value<int>("likeCount"),
                        DislikeCount = statistics?.Value<int>("dislikeCount"),
                        FavoriteCount = statistics?.Value<int>("favoriteCount"),
                        CommentCount = statistics?.Value<int>("commentCount"),

                        Tags = (from tag in snippet?.Value<JArray>("tags") select tag.ToString())?.ToList(),
                    };

                    youtubeItems.Add(youtubeItem);
                }

                return youtubeItems;
            }
            catch (Exception exception)
            {
                return youtubeItems;
            }
        }

        public Command ImageTappedCommand { get; }

        public void ImageTapped(YoutubeItem itemTapped)
        {
            var a = itemTapped;
            var launchActivity = DependencyService.Get<ILaunchActivity>();
            launchActivity.LaunchSingleVideo(itemTapped);
            //var singleActivity = new Intent(this,typeof(SingleVideoActivity))
            //StartActivity()
        }

        private void StartActivity()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
