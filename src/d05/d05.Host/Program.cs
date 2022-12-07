using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using d05.Nasa;
using d05.Nasa.Apod;
using d05.Nasa.Apod.Models;
using Microsoft.Extensions.Configuration;


ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = configurationBuilder.Build();
var api_key = configuration["ApiKey"];
/*
{
    INasaClient<object, object>[] test = new INasaClient<object, object>[3];
    var periodNasaClient = new PeriodNasaClient(configuration["ApiKey"]);
    var period = new KeyValuePair<DateTime, DateTime>(new DateTime(2022, 12, 01), new DateTime(2022, 12, 06));
    var result = await periodNasaClient.GetAsync(period);
    Console.WriteLine(result);
}
{
    var randomNasaClient = new RandomNasaClient(configuration["ApiKey"]);
    var result = await randomNasaClient.GetAsync(3);
    Console.WriteLine(result);
}
{
    var singleNasaClient = new SingleNasaClient(configuration["ApiKey"]);
    var result = await singleNasaClient.GetAsync(new DateTime(2022, 12, 07));
    Console.WriteLine(result);
}*/
{
    var apodClient = new ApodClient(configuration["ApiKey"]);
    await apodClient.GetAsync(5);
    var results = await apodClient.GetAsync(5);
    foreach (var mediaOfToday in results)
    {
        Console.WriteLine(mediaOfToday + Environment.NewLine);
    }
}
