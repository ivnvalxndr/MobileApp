using System.Net;
using Newtonsoft.Json.Linq;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        const string API = "ca88e8c853d9c9e518c3bfe1f4ff3cae";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void GetWeather_OnClicked(object? sender, EventArgs e)
        {
            string city = userInput.Text.Trim();
            if (city.Length < 2)
            {
                await DisplayAlert("Ошибка", "Город должен иметь больше символов", "Okay");
                return;
            }
            
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric";
            try
            {
                using (WebClient client = new WebClient())
                {
                    string response = client.DownloadString(url);

                    // Парсим json
                    var json = JObject.Parse(response);
                    string temp = json["main"]["temp"].ToString();
                    resultLabel.Text = "Погода сейчас: " + temp + "\u00b0C";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "Okay");
                throw;
            }
        }
    }
}
