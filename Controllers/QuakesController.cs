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
      if(string.IsNullOrEmpty(placeName))
      {
        return View();
      }
      LatLng latLng = LatLng.GetLatLng(placeName);
      return RedirectToAction("Details", latLng);
    }
    
    public IActionResult Details(LatLng latLng)
    {
      var allQuakes = Quake.GetQuakes(latLng.UserLat, latLng.UserLng);
      ViewBag.Possibility = Metrics.PossibilityOfQuake(allQuakes);
      ViewBag.AverageMagnitude = Metrics.StrengthOfQuake(allQuakes);
      ViewBag.QuakeCount = allQuakes.Count;
      ViewBag.MaxMag = Metrics.MaxMagnitude(allQuakes);
      ViewBag.UserData = latLng;
      
      return View(allQuakes);
    } 
  }
}

          // //Find Mode
          // int mode = allQuakes.Properties.Magnitude.GroupBy(magnitude => magnitude)
          //   .OrderByDescending(magnitude => magnitude.Count())
          //   .First()
          //   .Key;



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