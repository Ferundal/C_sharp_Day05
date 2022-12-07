using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using d05.Nasa.Apod.Models;

namespace d05.Nasa.Apod
{
    public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
    {
        private string _requestTemplate = "https://api.nasa.gov/planetary/apod?api_key=";
        private HttpClient _httpClient;
        public ApodClient(string apiKey)
        {
            _requestTemplate += apiKey;
            _httpClient = new HttpClient();
        }
        public async Task<MediaOfToday[]> GetAsync(int input)
        {
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            var request = $"{_requestTemplate}" +
                          $"&start_date={DateTime.Now.AddDays(-input).ToString("yyyy-MM-dd", cultureInfo)}" +
                          $"&end_date={DateTime.Now.ToString("yyyy-MM-dd", cultureInfo)}";
            var response = _httpClient.GetAsync(request);
            var responseString = await response.Result.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
            MediaOfToday[] responseMediaOfToday;
            try
            {
                responseMediaOfToday =
                    JsonSerializer.Deserialize<MediaOfToday[]>(responseString);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    $"GET{Environment.NewLine}" +
                    $"{request} returned Forbidden:{Environment.NewLine}" +
                    responseString);
                return responseMediaOfToday = Array.Empty<MediaOfToday>();
            }
            return responseMediaOfToday;
        }
    }
}