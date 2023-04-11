using System;
using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Widget;
using PaulSpotifyApp.Views;
using Xamarin.Forms;

namespace PaulSpotifyApp.Droid
{
    [Activity(Label = "PaulSpotifyApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            Window.SetStatusBarColor(Android.Graphics.Color.White);
            Window.SetNavigationBarColor(Android.Graphics.Color.White);
            
            MessagingCenter.Subscribe<PageDeux, Color>(this, "StatusBarColor", (sender, color) =>
            {
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor(color.ToHex()));
            });

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}