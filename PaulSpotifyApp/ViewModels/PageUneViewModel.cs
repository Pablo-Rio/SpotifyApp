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
            FirstColor = Color.CornflowerBlue;
            SecondColor = Color.WhiteSmoke;
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
            if (FirstColor == Color.CornflowerBlue)
            {
                FirstColor = Color.WhiteSmoke;
                SecondColor = Color.CornflowerBlue;
            }
            else
            {
                SecondColor = Color.WhiteSmoke;
                FirstColor = Color.CornflowerBlue;
            }
        }
    }
}