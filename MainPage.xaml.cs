using System.Net;
using Newtonsoft.Json.Linq;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string SensorUrl = "http://85.209.229.161:5001/sensor";

        public MainPage()
        {
            InitializeComponent();
        }

        private void UpdateTime(string time)
        {
            if (DateTime.TryParse(time, out var parsedTime))
            {
                TimeLabel.Text = parsedTime.ToString("HH:mm");
            }
            else
            {
                TimeLabel.Text = "Время неизвестно";
            }
        }

        private async Task<JObject?> FetchSensorDataAsync()
        {
            try
            {
                using (var client = new WebClient())
                {
                    string response = await client.DownloadStringTaskAsync(SensorUrl);
                    return JObject.Parse(response);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "Ок");
                return null;
            }
        }

        private async void OnGetTemperatureClicked(object? sender, EventArgs e)
        {
            var json = await FetchSensorDataAsync();
            if (json == null) return;

            resultTemp.Text = $"{json["Температура"]}°C";
            UpdateTime(json["Время"]?.ToString() ?? "");
        }

        private async void OnGetHumidityClicked(object? sender, EventArgs e)
        {
            var json = await FetchSensorDataAsync();
            if (json == null) return;

            resultHum.Text = $"{json["Влажность"]} %";
            UpdateTime(json["Время"]?.ToString() ?? "");
        }

        private async void OnGetPrecipitationClicked(object? sender, EventArgs e)
        {
            var json = await FetchSensorDataAsync();
            if (json == null) return;

            string hum = json["Осадки"]?.ToString();
            PrecipitationLabel.Text = $"{hum}";

            PrecipitationImage.Source = hum.ToLower().Contains("сухо") ? "sunny.png" : "rainy.png";
            UpdateTime(json["Время"]?.ToString() ?? "");
        }
    }
}
