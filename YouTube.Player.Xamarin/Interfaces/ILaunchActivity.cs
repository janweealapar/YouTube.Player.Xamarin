using System;
using System.Collections.Generic;
using System.Text;
using YouTube.Player.Xamarin.Models;

namespace YouTube.Player.Xamarin.Interfaces
{
    public interface ILaunchActivity
    {
        void LaunchSingleVideo(YoutubeItem item);
    }
}
