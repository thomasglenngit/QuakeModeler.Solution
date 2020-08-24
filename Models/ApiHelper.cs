using System.Threading.Tasks;
using System.Threading;
using RestSharp;


namespace QuakeModeler.Models
{
  public class ApiHelper
  {
    public static Task<string[]Result> LatLng(string apiKey, string placeName)
    {
      var apiCallTask = ApiHelper.ApiCall(apiKey, placeName);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      string[] latLng = JsonConvert.DeserializeObject<string[]>(jsonResponse["results"].ToString());

      return latLng;
    }
    public static async Task<string> ApiCall(string apiKey, string placeName)
    {
      RestClient client = new RestClient("https://api.opencagedata.com/geocode/v1/");
      RestRequest request = new RestRequest($"json?q={placeName}&key={apiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}