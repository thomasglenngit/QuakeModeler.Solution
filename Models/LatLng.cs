using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuakeModeler.Models
{
  public class LatLng
  {
    public string Lat { get; set; }
    public string Lng { get; set; }
    public static string[] LatLng(string apiKey, string placeName)
    {
      var apiCallTask = ApiHelper.ApiCall(apiKey, placeName);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      LatLng latLng = JsonConvert.DeserializeObject<LatLng>(jsonResponse["results"].ToString());

      return latLng;
    }
  }
}