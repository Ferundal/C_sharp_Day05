using System;
using System.Text.Json.Serialization;

namespace d05.Nasa.Apod.Models
{
    public class MediaOfToday
    {
        [JsonPropertyName("copyright")] public string Copyright { get; set; } 
        [JsonPropertyName("date")] public string Date { get; set; }
        [JsonPropertyName("explanation")] public string Explanation { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        public override string ToString()
        {
            return $"{Date}{Environment.NewLine}" +
                   $"{Title} by {Copyright}{Environment.NewLine}" +
                   $"{Explanation}{Environment.NewLine}" +
                   $"{Url}";
        }
    }
}