namespace RemoveFirstLast
{
   internal class Kata
   { public static string Remove_char(string s)
      {
         s = s.Remove(0, 1);
         s = s.Remove(s.Length - 1, 1);

         return s;
      }
   }
}