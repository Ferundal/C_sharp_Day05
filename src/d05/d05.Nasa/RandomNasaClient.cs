using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace d05.Nasa
{
    public class RandomNasaClient :INasaClient<int, Task<string>>
    {
        private string _requestTemplate = "https://api.nasa.gov/planetary/apod?api_key=";
        private HttpClient _httpClient;
        public RandomNasaClient(string apiKey)
        {
            _requestTemplate += apiKey;
            _httpClient = new HttpClient();
        }
        public Task<string> GetAsync(int input)
        {
            var request = $"{_requestTemplate}" +
                          $"&count={input.ToString()}";
            var response = _httpClient.GetAsync(request);
            return response.Result.Content.ReadAsStringAsync();
        }
    }
}