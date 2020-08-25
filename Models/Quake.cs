using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace QuakeModeler.Models
{
  public class Quake
  {
    public string Magnitude {get; set;}
    public string QuakeLat { get; set; }
    public string QuakeLng { get; set; }
    public Quake(string magnitude, string lat, string lng)
    {
      Magnitude = magnitude;
      QuakeLat = lat;
      QuakeLng = lng;
    }

    public static List<Quake> GetQuakes(string lat, string lng)
    {    
      // string[] latLng = LatLng.GetLatLng(placeName);
      var apiCallTask = ApiHelper.ApiCallGetEarthquakes(lat, lng);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      JObject[] quakes = JsonConvert.DeserializeObject<JObject[]>(jsonResponse["features"].ToString());

      List<Quake> listOfQuakes = new List<Quake>();

      foreach(var entry in quakes)
      {
        listOfQuakes.Add(new Quake(entry["properties"]["mag"].ToString(), entry["geometry"]["coordinates"][1].ToString(), entry["geometry"]["coordinates"][0].ToString()));
      }

      return listOfQuakes;
    } 
  }
}