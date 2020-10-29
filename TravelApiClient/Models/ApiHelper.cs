using System.Threading.Tasks;
using RestSharp;

namespace TravelApiClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"Places", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"places/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task Post(string newPlace)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"places", Method.POST);
      request.AddHeader("Content-Type", "application/json"); // add token
      request.AddJsonBody(newPlace);
      //System.Console.WriteLine("|||||||" + request.ToString());
      var response = await client.ExecuteTaskAsync(request);
      //System.Console.WriteLine("|||||||" + response.Content.ToString());
      //return response.Content;
    }
    public static async Task Put(int id, string newPlace)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"places/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json"); // add token
      request.AddJsonBody(newPlace);
      System.Console.WriteLine("|||||||" + newPlace);
      var response = await client.ExecuteTaskAsync(request);
      System.Console.WriteLine("|||||||" + response.Content.ToString());
    }
    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"places/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");//tolken
      var response = await client.ExecuteTaskAsync(request);
    }

  }
}