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
            var date = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.ReleaseDate;
            // Met la date au format français
            this.DateDeSortie.Text = date.Substring(8, 2) + "/" + date.Substring(5, 2) + "/" + date.Substring(0, 4);

            var longueur = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.Tracks.Items.Count;
            List<Musique> musiques = new List<Musique>();
            for (int i = 0; i < longueur; i++)
            {
                var musique = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.Tracks.Items[i]
                    .Name;
                var dureeMs = SpotifyService.Instance.GetSpotifyClient().Albums.Get(albumId).Result.Tracks.Items[i]
                    .DurationMs;
                var duree = TimeSpan.FromMilliseconds(dureeMs).ToString(@"m\:ss");
                musiques.Add(new Musique { NomDeLaMusique = musique, Duree = duree });
            }

            ListeDesTitres.ItemsSource = musiques;
        }
    }
}