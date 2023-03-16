using Day10Lab1;
using Day10Lab1c;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Press Return to start!");
Console.ReadLine();

ToDoItem mio = new ToDoItem() {
    Title = "Test",
    Description = "Test from CLI",
    CreationDate = DateTime.Now,
    DueDate = DateTime.Now.AddDays(5),
    PriorityLevel = 11,
    IsDone = false,
    IsMandatory = true
};

HttpClient MyCn = new HttpClient();
string URIBASE = "http://localhost:5152/api/ToDoItems";

//var s= await MyCn.PostAsJsonAsync<ToDoItem>(URIBASE, mio);
var s = await MyCn.PostAsJsonAsync(URIBASE, mio);

Console.WriteLine(s.RequestMessage);

HttpResponseMessage status = await MyCn.GetAsync(URIBASE);
if(status.IsSuccessStatusCode) {
    var lista= await status.Content.ReadFromJsonAsync<List<ToDoItem>>();
    foreach(ToDoItem item in lista) {
        Console.WriteLine($"{item.DueDate} => {item.Title}" );
    }
}


/*/Weather Forecast
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
//*/
Console.ReadLine();
