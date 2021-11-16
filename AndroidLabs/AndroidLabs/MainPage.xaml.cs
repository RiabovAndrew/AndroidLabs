using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AndroidLabs.API;
using Newtonsoft.Json;
using Windows.UI.Xaml.Media.Animation;
using Xamarin.Forms;

namespace AndroidLabs
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            label1.Text = Resource.HomePage;
            button1.Text = Resource.MoveButton;
            button2.Text = Resource.RefreshAPIButton;
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

        private void ButtonClicked2(object sender, EventArgs e)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Dnipro&appid=7194c8c1458f81b6a8381ea9a6267247";
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            var webResponse = (HttpWebResponse)webRequest?.GetResponse();

            string response;

            using( var streamReader = new StreamReader(webResponse?.GetResponseStream()))
            {
                response = streamReader?.ReadToEnd();
            }

            var weatherResponse = new WeatherResponse();
            if (response != string.Empty)
            {
                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            }

            label1.Text = weatherResponse.Name + ": " + Convert.ToInt32(weatherResponse.Main.Temp - 273.15) + "C";
        }

        private void ButtonClickedToolBoxItem1(object sender, EventArgs e)
        {
            label1.Text = Resource.HomePage;
            button1.IsVisible = false;
            image1.IsVisible = false;
            button2.IsVisible = false;
        }

        private void ButtonClickedToolBoxItem2(object sender, EventArgs e)
        {
            label1.Text = Resource.AnimationPage;
            button1.IsVisible = true;
            image1.IsVisible = true;
            button2.IsVisible = false;
        }

        private void ButtonClickedToolBoxItem3(object sender, EventArgs e)
        {
            button1.IsVisible = false;
            image1.IsVisible = false;
            button2.IsVisible = true;
        }
    }
}
