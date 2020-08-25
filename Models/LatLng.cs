using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuakeModeler.Models
{
  public class LatLng
  {
    public string UserLat { get; set; }
    public string UserLng { get; set; }
    public string PlaceName {get;set;}

    public LatLng(string placeName, string[] latLng)
    {
      PlaceName = placeName;
      UserLat = latLng[0];
      UserLng = latLng[1];
    }

    public static string[] GetLatLng(string placeName)
    {      
      var apiCallTask = ApiHelper.ApiCallLatLng(placeName);
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