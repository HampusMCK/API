using System.Text.Json;
using RestSharp;
using System.IO;

//Grund url
RestClient client = new("https://digi-api.com/api/v1/");

while (true)
{
    Console.WriteLine("Which digimon?");
    string digi = Console.ReadLine();
    //Specificerad url förlängning
    RestRequest request = new($"digimon/{digi}");

    //Resultat
    RestResponse response = client.GetAsync(request).Result;

    if (response.StatusCode == System.Net.HttpStatusCode.OK)
    {
        Digimon d = JsonSerializer.Deserialize<Digimon>(response.Content);

        Console.WriteLine("name: " + d.name + ", release date: " + d.releaseDate);
    }
    else
        Console.WriteLine(response.StatusCode);

    Console.ReadLine();
}
// Console.WriteLine(response.Content);
// File.WriteAllText("pokemon.json", response.Content);

