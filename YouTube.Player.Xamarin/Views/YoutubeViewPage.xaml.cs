using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YouTube.Player.Xamarin.ViewModels;

namespace YouTube.Player.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YoutubeViewPage : ContentPage
    {
        private readonly YoutubeViewModel _viewModel;
        public YoutubeViewPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new YoutubeViewModel();
        }
    }
}