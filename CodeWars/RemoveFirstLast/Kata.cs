namespace RemoveFirstLast;

internal class Kata
{ 
   public static string RemoveChar(string s)
   {
      s = s.Substring(1, s.Length - 2);

      return s;
   }
}