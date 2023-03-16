using Day10Lab1;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Press Return to start!");

Console.ReadLine();

HttpClient MyCn = new HttpClient();
string URIBASE = "http://localhost:5152/WeatherForecast";

HttpResponseMessage response = await MyCn.GetAsync(URIBASE);
if(response.IsSuccessStatusCode) {
    //Ok
    WeatherForecast[] Antani = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();
    foreach(var w in Antani) {
        Console.WriteLine("-----------  Weather Result -----------");
        Console.WriteLine($"{w.Date.ToLocalTime()} temp {w.TemperatureC}° ");
    }
    //EOW
} else {
    Console.WriteLine($"Sorry: {response.StatusCode}: {response.ReasonPhrase}");
}

Console.ReadLine();
