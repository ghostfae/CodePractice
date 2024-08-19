using System;

public class Diamond
{
   public static string print(int n)
   {
      if (n % 2 == 0 || n <= 0)
      {
         return null;
      }
      return MakeStar(n);
   }

   public static string MakeStar(int size)
   {
      string newString = "";
      int count = 1;
      int spaces = size / 2;
      int max = spaces + 1;
      // increase
      for (; count < max; count += 2, spaces--)
      {
         newString += new String(' ', spaces);
         newString += new String('*', count);
         newString += "\n";
      }

      newString += new String('*', max);
      // decrease
      for (; count > 0; count -= 2, spaces++)
      {
         newString += new String(' ', spaces);
         newString += new String('*', count);
         newString += "\n";
      }

      return newString;
   }
}