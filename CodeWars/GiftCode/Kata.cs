using System;

public class Kata
{
   public static string SortGiftCode(string code)
   {
      char[] array = code.ToCharArray();
      Array.Sort(array);
      return new string(array);
   }
}