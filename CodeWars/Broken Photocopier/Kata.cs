public class Kata
{ 
   public static string Broken(string x)
   {
      string newString = "";
      for (int i = 0; i < x.Length; i++)
      {
         if (x[i] == '1')
         {
            newString += '0';
         }
         else
         {
            newString += '1';
         }
      }
      return newString;
   }
}