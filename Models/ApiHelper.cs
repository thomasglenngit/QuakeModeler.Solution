using System.Threading.Tasks;
using System.Threading;
using RestSharp;

namespace QuakeModeler.Models
{
  public class ApiHelper
  {
    public static async Task<string> ApiCall(string apiKey, string placeName)
    {
      RestClient client = new RestClient("https://api.opencagedata.com/geocode/v1/");
      RestRequest request = new RestRequest($"json?q={placeName}&key={apiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}