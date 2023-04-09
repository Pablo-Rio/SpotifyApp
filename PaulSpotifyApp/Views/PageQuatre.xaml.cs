using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaulSpotifyApp.Service;
using Plugin.AudioRecorder;
using SpotifyAPI.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaulSpotifyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageQuatre : ContentPage
    {
        private readonly AudioPlayer _audioPlayer = new AudioPlayer();

        public PageQuatre()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            // ID de la piste Spotify que l'on veut lire
            var trackId = "5x6XRnn3aIUao8vzSvfBPx";

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "BQBEt1TzHfoIEFRuXFSXg0sBpayBVYWPmSf-p6PmFEEMr-iNAnnue1KMN7NIQ58DpjFR11w1OF9RKJxqaOLFYhUaIqmKXF1hk_5UiEtSQlFoRlzFhJpK");

            // Création du contenu de la requête
            var playContent = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    uris = new[] {"spotify:track:" + trackId},
                    position_ms = 0
                }), Encoding.UTF8, "application/json");
            
            var playResponse = await httpClient.PutAsync("https://api.spotify.com/v1/me/player/play", playContent);

            if (playResponse.IsSuccessStatusCode)
            {
                _audioPlayer.Play();
            }
            else
            {
                var errorA = playResponse.StatusCode.ToString();
                await DisplayAlert("Erreur", "Impossible de lancer la lecture de la piste "+errorA, "OK");
            }
        }
    }
}