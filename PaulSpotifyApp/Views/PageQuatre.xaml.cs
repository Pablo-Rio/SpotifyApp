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
    public partial class PageQuatre : ContentPage
    {
        public PageQuatre()
        {
            InitializeComponent();
            var trackId = "0pqnGHJpmpxLKifKRmU6WP";
            
            this.NomTitre.Text = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId)
                .Result.Name;
            this.NomArtiste.Text = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId)
                .Result.Artists[0].Name;
            this.NomAlbum.Text = "Album : " + SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId)
                .Result.Album.Name;
            this.ImageDeLAlbum.Source = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId)
                .Result.Album.Images[0].Url;
            var albumId = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId)
                .Result.Album.Id;
            this.NumeroDeLaPiste.Text = "Piste : " + SpotifyService.Instance.GetSpotifyClient().Tracks
                .Get(trackId)
                .Result.TrackNumber + " sur " + SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result
                .Tracks.Items.Count;
            var minutes = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId).Result
                .DurationMs / 1000 / 60;
            var secondes = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId).Result
                .DurationMs / 1000 % 60;
            this.Duree.Text = "Durée : " + minutes + " min " + secondes + " s";
            
            // Durée totale de l'album
            var longueur = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.Tracks.Items.Count;
            int dureeTotale = 0;
            for (int i = 0; i < longueur; i++)
            {
                dureeTotale += SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.Tracks.Items[i].DurationMs;
            }
            var minutesTotales = dureeTotale / 1000 / 60;
            var secondesTotales = dureeTotale / 1000 % 60;
            this.DureeTotale.Text = "Durée totale de l'album : " + minutesTotales + " min " + secondesTotales + " s";
        }
    }
}