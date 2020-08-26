using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace QuakeModeler.Models
{
  public class Quake
  {
    public double Magnitude {get; set;}
    public string QuakeLat { get; set; }
    public string QuakeLng { get; set; }
    public string Place {get; set;}
    public string Date {get; set;}
    public Quake(double magnitude, string lat, string lng, string place, string date)
    {
      Magnitude = magnitude;
      QuakeLat = lat;
      QuakeLng = lng;
      Place = place;
      Date = date;
    }

    public static List<Quake> GetQuakes(string lat, string lng)
    {    
      var apiCallTask = ApiHelper.ApiCallGetEarthquakes(lat, lng);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      JObject[] quakes = JsonConvert.DeserializeObject<JObject[]>(jsonResponse["features"].ToString());

      List<Quake> listOfQuakes = new List<Quake>();

      foreach(var entry in quakes)
      {
        listOfQuakes.Add(new Quake(Convert.ToDouble(entry["properties"]["mag"]), 
              entry["geometry"]["coordinates"][1].ToString(), 
              entry["geometry"]["coordinates"][0].ToString(),
              entry["properties"]["place"].ToString(),
              entry["properties"]["time"].ToString()));
      }

      return listOfQuakes;
    } 

    public static List<Quake> GetWorstQuakes()
    {    
      var apiCallTask = ApiHelper.ApiCallGetMaxMagnitude();
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      JObject[] quakes = JsonConvert.DeserializeObject<JObject[]>(jsonResponse["features"].ToString());

      List<Quake> listOfQuakes = new List<Quake>();

      for(int i=0; i < 5; i++)
      {
        listOfQuakes.Add(new Quake(Convert.ToDouble(quakes[i]["properties"]["mag"]), 
              quakes[i]["geometry"]["coordinates"][1].ToString(), 
              quakes[i]["geometry"]["coordinates"][0].ToString(),
              quakes[i]["properties"]["place"].ToString(),
              quakes[i]["properties"]["time"].ToString()));
      }
      return listOfQuakes;
    }
  }
}