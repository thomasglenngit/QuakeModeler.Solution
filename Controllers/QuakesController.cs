using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuakeModeler.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;
using System.Globalization;

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
        public IActionResult Index(string placeName)
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

        public double PossibilityOfQuake(List<Quake> quakes)

        //average number of quakes in a month based on ten years : quakes.Count / 120
        // 1 / (quakes.Count/120) * 100 = 100 / (quakes.Count/120)
        // possibility to have earthquake in a month: number of EQ in month / 30 * 100

        // earthquakes per month (x) = 10
        // Quakes.Count = 1200

        // 1/(1200/120)*100 = 20
        // 12000/1200 = 20

        {
            if(quakes.Count == 0)
            {
              return (double)0;
            }
            else
            {
              double possibility = quakes.Count * 10 / 365;      //average earthquakes per day          
            }
            return possibility;
        }



        public double StrengthOfQuake(List<Quake> quakes) // average number of quakes/year will be: quakes.Count / 10
        {
            if(quakes.Count == 0)
            {
              return (double)0;
            }
            double sum = 0;
           
            foreach (var item in quakes)
            {
                sum += Convert.ToDouble(quakes.Magnitude);
            }
            return sum / quakes.Count;
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