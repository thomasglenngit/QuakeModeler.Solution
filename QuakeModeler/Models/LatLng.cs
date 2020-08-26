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

    public LatLng()
    {
          
    }
    public LatLng(string placeName, string lat, string lng)
    {
      PlaceName = placeName;
      UserLat = lat;
      UserLng = lng;
    }

    public static LatLng GetLatLng(string placeName)
    {      
      var apiCallTask = ApiHelper.ApiCallLatLng(placeName);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      string lat = JsonConvert.DeserializeObject<string>(jsonResponse["results"][0]["geometry"]["lat"].ToString());
      string lng = JsonConvert.DeserializeObject<string>(jsonResponse["results"][0]["geometry"]["lng"].ToString());

      LatLng userObject = new LatLng(placeName, lat, lng);
      return userObject;
    }
  }
}