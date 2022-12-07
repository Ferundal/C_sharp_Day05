using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace d05.Nasa
{
    public class SingleNasaClient : INasaClient<DateTime, Task<string>>
    {
        private string _requestTemplate = "https://api.nasa.gov/planetary/apod?api_key=";
        private HttpClient _httpClient;
        public SingleNasaClient(string apiKey)
        {
            _requestTemplate += apiKey;
            _httpClient = new HttpClient();
        }
        public Task<string> GetAsync(DateTime input)
        {
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            var request = $"{_requestTemplate}" +
                          $"&start_date={input.ToString("yyyy-MM-dd", cultureInfo)}";
            var response = _httpClient.GetAsync(request);
            return response.Result.Content.ReadAsStringAsync();
        }
    }
}