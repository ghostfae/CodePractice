namespace SnailTwo;

public class SnailSolution
{
   public static List<(int, int)> Snail(int[][] array)
   {
      var snailList = new List<(int, int)>();
      var totalRows = array.Length;
      // we assume each row has the same amount of columns
      var totalCols = array[0].Length;

      int topSide = 0;
      int rightSide = totalCols - 1;
      int bottomSide = totalRows - 1;
      int leftSide = 0;

      while (topSide <= bottomSide && leftSide <= bottomSide)
      {
         var sides = GetSides(topSide, totalRows, snailList, rightSide, totalCols, bottomSide, leftSide);
         topSide = sides[0];
         rightSide = sides[1];
         bottomSide = sides[2];
         leftSide = sides[3];
      }
      return snailList;

   }

   private static List<int> GetSides(int topSide, int totalRows, List<(int, int)> snailList, int rightSide, int totalCols, int bottomSide,
      int leftSide)
   {
      for (int i = leftSide; i <= rightSide; i++)
      {
         snailList.Add((i, topSide));
         Console.WriteLine($"{i}, {topSide}");
      }
      topSide++;

      for (int i = topSide; i <= bottomSide; i++)
      {
         snailList.Add((rightSide, i));
         Console.WriteLine($"{rightSide}, {i}");
      }
      rightSide--;

      if (topSide <= bottomSide)
      {
         for (int i = rightSide; i >= leftSide; i--)
         {
            snailList.Add((i, bottomSide));
            Console.WriteLine($"{i}, {bottomSide}");
         }
         bottomSide--;
      }

      if (leftSide <= rightSide)
      {
         for (int i = bottomSide; i >= topSide; i--)
         {
            snailList.Add((leftSide, i));

            Console.WriteLine($"{leftSide}, {i}");
         }
         leftSide++;
      }

      return
      [
         topSide,
         rightSide,
         bottomSide,
         leftSide
      ]; ;
   }

   public static void Main()
   {
      int[][] array =
      [
         [1, 2, 3],
         [4, 5, 6],
         [7, 8, 9],
         [10, 11, 12]
      ];

      Snail(array);
   }
}