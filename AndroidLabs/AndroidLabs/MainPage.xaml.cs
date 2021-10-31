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
        private void ButtonClicked(object sender, EventArgs e)
        {
            label1.Text = (++num).ToString();
        }
    }
}
