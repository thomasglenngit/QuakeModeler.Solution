using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuakeModeler.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace QuakeModeler.Controllers
{
    public class QuakesController : Controller
    {
        //form for input, no data
        public IActionResult Index()
        {
          return View();
        }
        //model = result of an api call
        //all earthquakes for a given area
        public IActionResult ReturnAll(string apiKey, string placeName, int maxRadiusKm, int startTime, int endTime)
        {

          string[] latLng = LatLng.GetLatLng(apiKey, placeName); 
          var allQuakes = Quake.GetQuakes(latLng[0], latLng[1], maxRadiusKm, startTime, endTime);
          //Find Mode
          int mode = allQuakes.Properties.Magnitude.GroupBy(magnitude => magnitude)
            .OrderByDescending(magnitude => magnitude.Count())
            .First()
            .Key;
          //Find Frequency
          int frequency = allQuakes.Count() / (endTime - startTime);
          
          int largest = allQuakes.Max();

          int average = 0;
          int[] statsArray = {average, mode, largest, frequency}; 

          //Find Average

          for (int i = 0; i < allQuakes.Count(); i++)
          {
            allQuakes[i].Properties.Magnitude += average;
            average /= allQuakes.Count();
          }

          return View(allQuakes);
        }

    }
}

//for (int i = 0; i < allDreams.Count; i++)
          // {
          //   //search for string1
          //   if (string1 != null && allQuakes[i].Field.ToLower().Contains(string1.ToLower()))
          //   {
          //     searchObject.Add(allQuakes[i]);
          //   }
          //   //search for string2
          //   if (string2 != null && allQuakes[i].Field.ToLower().Contains(string2.ToLower()))
          //   {
          //     searchObject.Add(allQuakes[i]);
          //   }
          //   //search for number1
          //   if (number1 != null && allQuakes[i].Field == number1)
          //   {
          //     searchObject.Add(allQuakes[i]);
          //   }
          //   //search for number2
          //   if (number2 != null && allQuakes[i].Field == number2)
          //   {
          //     searchObject.Add(allQuakes[i]);
          //   }
          // }