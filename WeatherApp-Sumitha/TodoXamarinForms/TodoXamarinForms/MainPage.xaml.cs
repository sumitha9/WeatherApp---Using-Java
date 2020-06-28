using System;
using Xamarin.Forms;

namespace TodoXamarinForms
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;

        // Button button = new Button { };

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();

        }

        protected override void OnAppearing()

        {

            OnGetWeatherButtonClicked(null, null);

        }

        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text.Trim()}";
            // requestUri += "&units=metric&lang=hi"; // or units=metric
            requestUri += $"&units={_unitEntry.Text.Trim()}"; // or units=metric
            requestUri += $"&lang={_langEntry.Text.Trim()}"; // or units=metric
            requestUri += $"&zip={_zipEntry.Text.Trim()}"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}



