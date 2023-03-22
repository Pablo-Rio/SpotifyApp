using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliseSpotifyApp.Service;
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

            this.NomArtiste.Text = SpotifyService.Instance.GetSpotifyClient().Artists.Get("44TGR1CzjKBxSHsSEy7bi9")
                .Result.Name;
        }
    }
}