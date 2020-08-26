using System.Collections.Generic;
using System;

namespace QuakeModeler.Models
{
  public class Metrics
  {
    //average number of quakes in a month based on ten years : quakes.Count / 120
    // 1 / (quakes.Count/120) * 100 = 100 / (quakes.Count/120)
    // possibility to have earthquake in a month: number of EQ in month / 30 * 100

    // earthquakes per month (x) = 10
    // Quakes.Count = 1200

    // 1/(1200/120)*100 = 20
    // 12000/1200 = 20
    public static double PossibilityOfQuake(List<Quake> quakes)
    {
      double possibility = 0;
      if(quakes.Count != 0)
      {
        possibility = quakes.Count * 10 / 365;
      }
      return possibility;
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
        return sum / quakes.Count;
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