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
    public partial class PageDeux : ContentPage
    {
        public PageDeux()
        {
            InitializeComponent();
            var woodkidId = "44TGR1CzjKBxSHsSEy7bi9";

            this.NomArtiste.Text = SpotifyService.Instance.GetSpotifyClient().Artists.Get(woodkidId)
                .Result.Name;
            this.ImageDeLArtiste.Source = SpotifyService.Instance.GetSpotifyClient().Artists.Get(woodkidId)
                .Result.Images[0].Url;
            this.GenresMusicaux.Text = "Genres musicaux : " + SpotifyService.Instance.GetSpotifyClient().Artists.Get(woodkidId)
                .Result.Genres[0];
            this.NombreFollowers.Text = SpotifyService.Instance.GetSpotifyClient().Artists.Get(woodkidId)
                .Result.Followers.Total + " followers";
            this.Popularite.Text = "Popularité : " + SpotifyService.Instance.GetSpotifyClient().Artists.Get(woodkidId)
                .Result.Popularity;
        }
    }
}