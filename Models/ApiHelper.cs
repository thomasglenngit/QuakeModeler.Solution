using System.Threading.Tasks;
using System.Threading;
using RestSharp;
using System;

namespace QuakeModeler.Models
{
  public class ApiHelper
  {
    public static async Task<string> ApiCallLatLng(string apiKey, string placeName)
    {
      RestClient client = new RestClient("https://api.opencagedata.com/geocode/v1/");
      RestRequest request = new RestRequest($"json?q={placeName}&key={apiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

//https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&latitude=47.6038321&longitude=-122.330062&maxradiuskm=20&starttime=2019-07-01&endtime=2019-09-01
    public static async Task<string> ApiCallGetEarthquakes(string lat, string lng)
    {
      DateTime endDay = DateTime.Now;
      string end = endDay.ToString("yyyy-MM-dd");
      DateTime startDay = endDay.AddYears(-10);
      string start = startDay.ToString("yyyy-MM-dd");
      RestClient client = new RestClient("https://earthquake.usgs.gov/fdsnws/event/1/");
      RestRequest request = new RestRequest($"query?format=geojson&latitude={lat}&longitude={lng}&maxradiuskm=10&starttime={start}&endtime={end}&minmag=1.50&orderby%3Dmagnitude", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}