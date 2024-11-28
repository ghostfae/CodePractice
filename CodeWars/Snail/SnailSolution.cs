using System.ComponentModel.DataAnnotations;

public class SnailSolution
{
   private static int? InnerArraySize(int[][] array)
   {
      foreach (var inner in array)
      {
         if (inner.Length != array.Length) 
            return null;
      }
      return array.Length;
   }

   public static int[] Snail(int[][] array)
   {
      if (InnerArraySize(array) == null)
      {
         throw new ArgumentException("input array should have equal sizes");
      }
      
      var snailList = new List<int>();
      var size = array.Length;
      if (size > 0)
      {
         int row = 0;
         int column = 0;

         for (; size > 1; size -= 2, row++, column++)
         {
            Perimeter(array, snailList, row, column, size);
         }

         if (size > 0)
         {
            snailList.Add(array[row][column]);
         }
      }
      return snailList.ToArray();
   }

   public static void Perimeter(int[][] array, List<int> result, int row, int column, int size)
   {
      Side(array, result, row, column, size - 1, 0, 1); // top
      Side(array, result, row, column + size - 1, size - 1, 1, 0); // right
      Side(array, result, row + size - 1, column + size - 1, size - 1, 0, -1); // bottom
      Side(array, result, row + size - 1, column, size - 1, -1, 0); // left
   }

   public static void Side(int[][] array, List<int> result, int row, int column, int count, int deltaRow, int deltaColumn)
   {
      for (; count > 0; count--, row += deltaRow, column += deltaColumn)
      {
         result.Add(array[row][column]);
      }
   }
}