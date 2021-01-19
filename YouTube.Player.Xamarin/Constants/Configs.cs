using System;
using System.Collections.Generic;
using System.Text;

namespace YouTube.Player.Xamarin.Constants
{
    public static class Configs
    {
        // use this link to get an api_key : https://console.developers.google.com/apis/api/youtube/
        public const string ApiKey = "AIzaSyAfuwWWMkefg9UUIVY5d04EFMVznY3RXlU";

        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.videos.list 
        public static string apiUrlForChannel = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=20&channelId="
            + "UCSNX8VGaawLFG_bAZuMyQ3Q"
            //+ "Your_ChannelId"
            + "&key="
            + ApiKey;

        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.playlistItems.list
        public static string apiUrlForPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=20&playlistId="
            + "PL3sMvHhm3CxTY9GNKinIXdHUp_bl_XIPt"
            //+ "Your_PlaylistId"
            + "&key="
            + ApiKey;

        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.search.list
        public static string apiUrlForVideosDetails = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
            + "{0}"
            //+ "0ce22qhacyo,j8GU5hG-34I,_0aQJHoI1e8"
            //+ "Your_Videos_Id"
            + "&key="
            + ApiKey;
    }
}
