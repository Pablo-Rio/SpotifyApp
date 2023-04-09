using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager;
using PaulSpotifyApp.Service;
using Xamarin.Forms;

namespace PaulSpotifyApp
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            SpotifyService.Instance.ConnectSpotify();
            CrossMediaManager.Current.Init();
        }
    }
}
