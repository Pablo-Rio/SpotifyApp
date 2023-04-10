using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaulSpotifyApp.Service;
using SpotifyAPI.Web;
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
            var playlistId = "69d0rVifC3AuhnZOQDMXLC";
            
            this.NomPlaylist.Text = SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId)
                .Result.Name;
            this.Autheur.Text = "par " + SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId)
                .Result.Owner.DisplayName;
            this.NbreDeTitres.Text = SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId)
                .Result.Tracks.Total + " titres";
            
            
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
                .Get(trackId).Result.TrackNumber;
            var minutes = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId).Result
                .DurationMs / 1000 / 60;
            var secondes = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId).Result
                .DurationMs / 1000 % 60;
            this.Duree.Text = "Durée : " + minutes + " min " + secondes + " s";
            
            // Durée totale de la playlist
            var longueurTotale = SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId).Result.Tracks.Total;
            int dureeTotale = 0;
            for (int i = 0; i < longueurTotale; i++)
            {
                //dureeTotale += SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId).Result.Tracks.Items[i].Track.GetHashCode();
            }
            var minutesTotales = dureeTotale / 1000 / 60;
            var secondesTotales = dureeTotale / 1000 % 60;
            this.DureeTotale.Text = "Durée totale de la playlist : " + minutesTotales + " min " + secondesTotales + " s";
            
            // Liste des titres de la playlist
            var playlist = SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId).Result;
            var tracks = playlist.Tracks.Items;
            List<string> trackIds = new List<string>();
            List<string> trackNames = new List<string>();
            foreach (var track in tracks)
            {
                var fullTrack = track.Track as FullTrack;
                trackNames.Add(fullTrack.Name);
                trackIds.Add(fullTrack.Id);
            }
            this.ListeDesTitres.ItemsSource = trackNames;
        }
    }
}