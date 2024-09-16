namespace ReverseWords
{
   using System;

   public class ReverseWords
   {
      public string ReverseLetter(string str)
      {
         string reversed = "";

         for (int i = 0; i < str.Length; i++)
         {
            if (char.IsLetter(str[(str.Length - 1) - i]))
            {
               reversed += LastLetter(str, i);
            }
         }

         return reversed;
      }

      private char LastLetter(string str, int i)
      {
         return str[(str.Length - 1) - i];
      }
   }
}