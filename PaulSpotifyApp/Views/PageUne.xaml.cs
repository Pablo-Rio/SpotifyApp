using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XXXXXX;

namespace PaulSpotifyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageUne : ContentPage
    {
        public PageUne()
        {
            InitializeComponent();
            BindingContext = PageUneViewModel.Instance;
        }
        
        private void Button_OnClicked(object sender, EventArgs e)
        {
            PageUneViewModel.Instance.UpdateColors();
        }

        private void OnImageTapped(object sender, EventArgs e)
        {
            Image fermee = this.FindByName<Image>("EnveloppeF");
            fermee.IsVisible = false;
            Image ouverte = this.FindByName<Image>("EnveloppeO");
            ouverte.IsVisible = true;
            Image lettre = this.FindByName<Image>("Lettre");
            lettre.IsVisible = true;
            StackLayout tableau = this.FindByName<StackLayout>("Tableau");
            tableau.IsVisible = true;
        }
    }
}