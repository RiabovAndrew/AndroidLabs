using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;
using Xamarin.Forms;

namespace AndroidLabs
{
    public partial class MainPage : ContentPage
    {
        private int num;
        public MainPage()
        {
            InitializeComponent();
        }
        private async void ButtonClicked(object sender, EventArgs e)
        {
            //label1.Text = (++num).ToString();
            await label1.RotateTo(360, 2000);
        }

        private async void ButtonClicked2(object sender, EventArgs e)
        {
            await label1.RotateTo(360, 2000);
        }
    }
}
