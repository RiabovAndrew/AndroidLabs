using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;
using Xamarin.Forms;

namespace AndroidLabs
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void ButtonClicked(object sender, EventArgs e)
        {
            new Animation
            {
                { 0, 0.5, new Animation (v => image1.TranslationY = v, 0, 200) },
                { 0.5, 1, new Animation (v => image1.TranslationY = v, 200, 0) },
                { 0, 1, new Animation(v => image1.Rotation = v, 0, 360) },
                { 0, 0.5, new Animation(v => image1.Scale = v, 1, 0.7) },
                { 0.5, 1, new Animation(v => image1.Scale = v, 0.7, 1) }
            }
            .Commit(this, "Bounce", length: 10000, repeat: () => true);
        }
    }
}
