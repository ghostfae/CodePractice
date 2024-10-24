using NUnit.Framework.Constraints;

namespace LuxuriousHouse;

public class Kata
{
   // enumerate houses from left to right
   // luxurious if number of floors is greater than the house from the right of it

   // how many floors added to 'i'th house to make it luxurious
   // for each i from 1 to n

   // input array of +int, representing floors in each house
   // ith element is the number of floors in the ith house
   // 1 <= houses.length <= 1000

   // output array of same length as input, 'i'th element represents number of floors that should be added to make it luxurious
   // e.g. input [1, 2, 3, 1, 2] output [3, 2, 0, 2, 0]
   public int[] LuxuriousHouse(int[] nHouses)
   {
      var nFloors = new int[nHouses.Length];

      for (int i = nFloors.Length - 1; i >= 0; i--)
      {
         nFloors.SetValue(CalculateFloors(nHouses, nFloors, i), i);
      }

      Console.WriteLine(nFloors);
      return nFloors;
   }

   private int CalculateFloors(int[] nHouses, int[] nFloors, int i)
   {
      // check if value has something to right of it
      if (i >= nHouses.Length - 1) return 0;

      // check if right house has more floors than it
      if (nHouses[i] > nHouses[i + 1]) return 0;

      // calculate how many floors need to be added to be greater than the one to the right
      if (i != 0) return nHouses[i + 1] - nHouses[i] + 1;

      return nHouses[i + 1] + nFloors[i + 1] - nHouses[i];
   }
}