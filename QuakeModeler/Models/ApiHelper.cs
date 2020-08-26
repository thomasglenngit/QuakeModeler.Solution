using System.Threading.Tasks;
using System.Threading;
using RestSharp;
using System;

namespace QuakeModeler.Models
{
  public class ApiHelper
  {
    public static async Task<string> ApiCallLatLng(string placeName)
    {
      RestClient client = new RestClient("https://api.opencagedata.com/geocode/v1/");
      RestRequest request = new RestRequest($"json?q={placeName}&key={EnvironmentVariables.ApiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiCallGetEarthquakes(string lat, string lng)
    {
      DateTime endDay = DateTime.Now;
      string end = endDay.ToString("yyyy-MM-dd");
      DateTime startDay = endDay.AddYears(-20);
      string start = startDay.ToString("yyyy-MM-dd");
      RestClient client = new RestClient("https://earthquake.usgs.gov/fdsnws/event/1/");
      RestRequest request = new RestRequest($"query?format=geojson&latitude={lat}&longitude={lng}&maxradiuskm=50&starttime={start}&endtime={end}&minmag=2.50&orderby%3Dmagnitude", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiCallGetMaxMagnitude()
    {
      DateTime endDay = DateTime.Now;
      string end = endDay.ToString("yyyy-MM-dd");      
      RestClient client = new RestClient("https://earthquake.usgs.gov/fdsnws/event/1/");
      RestRequest request = new RestRequest($"query?format=geojson&latitude=39.547367&longitude=-105.238256&orderby=magnitude&maxradiuskm=2200&starttime=1950-01-01&endtime={end}&minmag=7", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}