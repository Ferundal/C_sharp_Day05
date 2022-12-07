using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace d05.Nasa
{
    public class PeriodNasaClient : INasaClient<KeyValuePair<DateTime, DateTime>, Task<string>>
    {
        private string _requestTemplate = "https://api.nasa.gov/planetary/apod?api_key=";
        private HttpClient _httpClient;
        public PeriodNasaClient(string apiKey)
        {
            _requestTemplate += apiKey;
            _httpClient = new HttpClient();
        }
        
        public Task<string> GetAsync(KeyValuePair<DateTime, DateTime> input)
        {
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            var request = $"{_requestTemplate}" +
                          $"&start_date={input.Key.ToString("yyyy-MM-dd", cultureInfo)}" +
                          $"&end_date={input.Value.ToString("yyyy-MM-dd", cultureInfo)}";
            var response = _httpClient.GetAsync(request);
            return response.Result.Content.ReadAsStringAsync();
        }
    }
}