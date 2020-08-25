using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace QuakeModeler.Models
{
  public class Quake
  {
    public string Magnitude {get; set;}
    public Quake(string magnitude)
    {
      Magnitude = magnitude;
    }
    public static List<Quake> GetQuakes(string apiKey, string placeName)
    {      
      string[] latLng = LatLng.GetLatLng(apiKey,placeName);
      var apiCallTask = ApiHelper.ApiCallGetEarthquakes(latLng[0], latLng[1]);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      JObject[] quakes = JsonConvert.DeserializeObject<JObject[]>(jsonResponse["features"].ToString());

      List<Quake> listOfQuakes = new List<Quake>();

      foreach(var entry in quakes)
      {
          listOfQuakes.Add(new Quake(entry["properties"]["mag"].ToString()));
      }

      return listOfQuakes;
    } 
  }
}