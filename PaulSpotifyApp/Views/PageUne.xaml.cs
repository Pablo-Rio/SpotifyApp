using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}