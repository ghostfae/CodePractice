namespace SnailTwo;

public class SnailSolutionV2
{
   public static List<(int, int)> Snail(int totalCols, int totalRows)
   {
      var snailList = new List<(int, int)>();

      int topSide = 0;
      int rightSide = totalCols - 1;
      int bottomSide = totalRows - 1;
      int leftSide = 0;

      while (topSide <= bottomSide && leftSide <= bottomSide)
      {
         var sides = GetSides(topSide, snailList, rightSide, bottomSide, leftSide);
         topSide = sides[0];
         rightSide = sides[1];
         bottomSide = sides[2];
         leftSide = sides[3];
      }
      return snailList;

   }

   private static List<int> GetSides(int topSide, List<(int, int)> snailList, int rightSide, int bottomSide,
      int leftSide)
   {
      for(int i = leftSide; i <= rightSide; i++)
      {
         snailList.Add((i, topSide));
      }
      topSide++;

      for (int i = topSide; i <= bottomSide; i++)
      {
         snailList.Add((rightSide, i));
      }
      rightSide--;

      if (topSide <= bottomSide)
      {
         for (int i = rightSide; i >= leftSide; i--)
         {
            snailList.Add((i, bottomSide));
         }
         bottomSide--;
      }

      if (leftSide <= rightSide)
      {
         for (int i = bottomSide; i >= topSide; i--)
         {
            snailList.Add((leftSide, i));
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
}