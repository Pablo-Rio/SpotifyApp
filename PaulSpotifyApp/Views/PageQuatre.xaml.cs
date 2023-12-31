﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<string> trackIds;
        private List<string> trackNames;
        private String trackId;
        private Boolean isPlaying = false;
        public PageQuatre()
        {
            InitializeComponent();
            // Playlist de Ramin Djawadi
            var playlistId = "37i9dQZF1DZ06evO0HqFDa";

            this.NomPlaylist.Text = SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId)
                .Result.Name;
            this.Auteur.Text = "par " + SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId)
                .Result.Owner.DisplayName;
            this.NbreDeTitres.Text = SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId)
                .Result.Tracks.Total + " titres";

            int dureeTotale = 0;

            // Liste des titres de la playlist
            var playlist = SpotifyService.Instance.GetSpotifyClient().Playlists.Get(playlistId).Result;
            var tracks = playlist.Tracks.Items;
            trackIds = new List<string>();
            trackNames = new List<string>();
            foreach (var track in tracks)
            {
                var fullTrack = track.Track as FullTrack;
                trackNames.Add(fullTrack.Name);
                trackIds.Add(fullTrack.Id);
                dureeTotale += fullTrack.DurationMs;
            }
            this.ListeDesTitres.ItemsSource = trackNames;
            
            // Durée totale de la playlist
            var minutesTotales = dureeTotale / 1000 / 60;
            var secondesTotales = dureeTotale / 1000 % 60;
            this.DureeTotale.Text = "Durée totale de la playlist : " + minutesTotales + " min " + secondesTotales + " s";
        }

        private void Cell_OnTapped(object sender, EventArgs e)
        {
            // Affiche un l'id de l'élément du tableau trackIds correspondant à l'élément du tableau trackNames

            var cell = sender as ViewCell;
            var trackName = cell.View.BindingContext as string;
            trackId = trackIds[trackNames.IndexOf(trackName)];

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
            this.NumeroDeLaPiste.Text = "Piste : " + (trackNames.IndexOf(trackName) + 1);
            var minutes = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId).Result
                .DurationMs / 1000 / 60;
            var secondes = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId).Result
                .DurationMs / 1000 % 60;
            this.Duree.Text = "Durée : " + minutes + " min " + secondes + " s";

            var url = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId).Result.PreviewUrl;
            this.PlayPause.IsVisible = false;

            _audioPlayer.Pause();
            if (url != null)
            {
                this.PlayPause.IsVisible = true;
            }
        }
        private void OnPlayPauseClicked(object sender, EventArgs e)
        {
            var url = SpotifyService.Instance.GetSpotifyClient().Tracks.Get(trackId).Result.PreviewUrl;
            if (url != null)
            {
                if (isPlaying)
                {
                    _audioPlayer.Pause();
                    this.PlayPause.Text = "▶";
                    isPlaying = false;
                }
                else
                {
                    _audioPlayer.Play(url);
                    this.PlayPause.Text = "■";
                    isPlaying = true;
                }
            }
        }
    }
}