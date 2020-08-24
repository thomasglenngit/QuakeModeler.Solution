using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuakeModeler.Models
{
  public class LatLng
  {
    public static string[] GetLatLng(string apiKey, string placeName)
    {      
      var apiCallTask = ApiHelper.ApiCall("ff7663b329b240729be1c4bfe4f03fa9", "Seattle");
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      string lat = JsonConvert.DeserializeObject<string>(jsonResponse["results"][0]["geometry"]["lat"].ToString());
      string lng = JsonConvert.DeserializeObject<string>(jsonResponse["results"][0]["geometry"]["lng"].ToString());

      string[] latLng = new string[2];
      latLng[0] = lat;
      latLng[1] = lng;
      return latLng;
    }
  }
}