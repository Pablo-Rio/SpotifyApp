using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaulSpotifyApp.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaulSpotifyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTrois : ContentPage
    {
        public PageTrois()
        {
            InitializeComponent();
            var albumId = "4xnYue1MP5wspZzWyzEkmQ";

            this.NomAlbum.Text = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId)
                .Result.Name;
            this.ImageDeLAlbum.Source =
                SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.Images[0].Url;
            this.Artiste.Text = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.Artists[0].Name;
            this.DateDeSortie.Text = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.ReleaseDate;
            
            var longueur = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.Tracks.Items.Count;
            string[] tableau = new string[longueur];
            for (int i = 0; i < longueur; i++)
            {
                tableau[i] = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.Tracks.Items[i].Name;
            }
            this.ListeDesTitres.ItemsSource = tableau;
        }
    }
}