using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuakeModeler.Models
{
  public class LatLng
  {
    public string Lat { get; set; }
    public string Lng { get; set; }
    public static void GetLatLng(string apiKey, string placeName)
    {
      System.Console.WriteLine("hello");
      var apiCallTask = ApiHelper.ApiCall(EnvironmentVariables.ApiKey, "Seattle");
      var result = apiCallTask.Result;

      //JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      //JObject latLng = JsonConvert.DeserializeObject<JObject>(jsonResponse["results"][0]["geometry"].ToString());
      //System.Console.WriteLine(latLng);
      //return latLng;
      System.Console.WriteLine("hello");
    }
  }
}