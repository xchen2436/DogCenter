using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace Project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetDog();

        }
        private async void GetDog()
        {
            string url = "https://api.thedogapi.com/v1/breeds";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var albums = JsonConvert.DeserializeObject<List<Dog>>(response);
                carouselview.ItemsSource = albums;

            }
        }

        async void Buttonsignout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        async void ButtonBuy_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuyPage());
        }
    }
}
