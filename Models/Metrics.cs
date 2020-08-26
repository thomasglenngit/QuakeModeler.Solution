using System.Collections.Generic;
using System;

namespace QuakeModeler.Models
{
  public class Metrics
  {
    public static double PossibilityOfQuake(List<Quake> quakes)
    {
      double possibility = 0;
      if(quakes.Count != 0)
      {
        possibility = quakes.Count * (double)10 / (double)365;
      }
      return Math.Round(possibility, 3);
    }

    public static double StrengthOfQuake(List<Quake> quakes) 
    {
      if(quakes.Count == 0)
      {
        return (double)0;
      }
      double sum = 0;      
      foreach (var item in quakes)
      {
          sum += Convert.ToDouble(item.Magnitude);
      }
      return Math.Round(sum / quakes.Count, 2);
    }

    public static double MaxMagnitude(List<Quake> quakes)
    {
      if(quakes.Count == 0)
      {
        return (double)0;
      }
      double max = 0;
      for(int i=0; i<quakes.Count; i++)
      {
        if(Convert.ToDouble(quakes[i].Magnitude) > max)
        {
          max = Convert.ToDouble(quakes[i].Magnitude);
        }
      }
      return max;
    }
  }
}