using System;
using System.Collections.Generic;
using Xamarin.Forms;
using YouTube.Player.Xamarin.ViewModels;
using YouTube.Player.Xamarin.Views;

namespace YouTube.Player.Xamarin
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
