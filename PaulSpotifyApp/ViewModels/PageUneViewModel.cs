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
            FirstColor = Color.GreenYellow;
            SecondColor = Color.Red;
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

        public void UpdateColors()
        {
            if (FirstColor == Color.GreenYellow)
            {
                FirstColor = Color.Red;
                SecondColor = Color.GreenYellow;
            }
            else
            {
                SecondColor = Color.Red;
                FirstColor = Color.GreenYellow;
            }
        }
    }
}