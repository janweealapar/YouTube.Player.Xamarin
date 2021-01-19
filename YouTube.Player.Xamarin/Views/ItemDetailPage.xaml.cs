using System.ComponentModel;
using Xamarin.Forms;
using YouTube.Player.Xamarin.ViewModels;

namespace YouTube.Player.Xamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}