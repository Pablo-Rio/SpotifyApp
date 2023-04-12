using Xamarin.Forms;

namespace XXXXXX
{
    public class PageUneViewModel : BaseViewModel
    {
        #region Instance

        public static PageUneViewModel Instance { get; } = new PageUneViewModel();

        #endregion

        public PageUneViewModel()
        {
            FirstColor = Color.FromHex("#00cd52");
            SecondColor = Color.White;
            BlackS = Color.FromHex("#00cd52");
            WhiteS = Color.FromHex("#00cd52");
        }

        public Color FirstColor
        {
            get
            {
                return GetValue<Color>();
            }
            set
            {
                SetValue(value);
            }
        }
        public Color SecondColor
        {
            get
            {
                return GetValue<Color>();
            }
            set
            {
                SetValue(value);
            }
        }
        
        public Color WhiteS
        {
            get
            {
                return GetValue<Color>();
            }
            set
            {
                SetValue(value);
            }
        }
        
        public Color BlackS
        {
            get
            {
                return GetValue<Color>();
            }
            set
            {
                SetValue(value);
            }
        }
        
        public static Color Lerp(Color a, Color b, float t)
        {
            return new Color(
                a.R + (b.R - a.R) * t,
                a.G + (b.G - a.G) * t,
                a.B + (b.B - a.B) * t,
                a.A + (b.A - a.A) * t);
        }


        public void UpdateColors()
        {
            if (FirstColor == Color.FromHex("#00cd52"))
            {
                FirstColor = Color.White;
                SecondColor = Color.FromHex("#00cd52");
            }
            else
            {
                SecondColor = Color.White;
                FirstColor = Color.FromHex("#00cd52");
            }
    
            // Le Blacks se rapproche très doucement du noir
            BlackS = Lerp(BlackS, Color.Black, 0.05f);
    
            // Le WhiteS se rapproche très doucement du blanc
            WhiteS = Lerp(WhiteS, Color.White, 0.05f);
        }
    }
}