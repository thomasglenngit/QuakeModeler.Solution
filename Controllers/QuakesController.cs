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

        [HttpPost]
        public ActionResult Index(string placeName)
        {
          LatLng latLng = LatLng.GetLatLng(placeName);
          return RedirectToAction("Details", latLng);
        }
        //model = result of an api call
        //all earthquakes for a given area
        
        public IActionResult Details(LatLng latLng)
        {
          var allQuakes = Quake.GetQuakes(latLng.UserLat, latLng.UserLng);
          ViewBag.UserData = latLng;
          
          // //Find Mode
          // int mode = allQuakes.Properties.Magnitude.GroupBy(magnitude => magnitude)
          //   .OrderByDescending(magnitude => magnitude.Count())
          //   .First()
          //   .Key;
          // //Find Frequency
          // int frequency = allQuakes.Count() / (endTime - startTime);
          
          // int largest = allQuakes.Max();

          // int average = 0;
          // int[] statsArray = {average, mode, largest, frequency}; 

          // //Find Average

          // for (int i = 0; i < allQuakes.Count(); i++)
          // {
          //   allQuakes[i].Properties.Magnitude += average;
          //   average /= allQuakes.Count();
          // }

          return View(allQuakes);
        }

        //public int PossibilityOfQuake(List<Quake> quakes)
        // average number of quakes in a month based on ten years : quakes.Count / 120
        //
        // {
        //     if(quakes.Count == 0)
        //     {
        //       return 0;
        //     }
        //     else
        //     {
        //       int possibility = 120 / quakes.Count;              
        //     }
        //     return possibility;
        // }

        // public int StrengthOfQuake(List<Quake> quakes) // average number of quakes/year will be: quakes.Count / 10
        // {
        //     var 
        // }
      
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