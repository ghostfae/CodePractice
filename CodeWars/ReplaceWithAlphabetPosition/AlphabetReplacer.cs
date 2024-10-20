using System.Text.RegularExpressions;

namespace ReplaceWithAlphabetPosition;

public class AlphabetReplacer
{
   // the kata without looking up the answer
   public string AlphabetPosition(string text)
   {
      text = text.ToLower();

      char[] alphabet =
      [
         'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
         'w', 'x', 'y', 'z'
      ];
      var newText = string.Empty;

      foreach (var character in text)
      {
         if (alphabet.Contains(character))
         {
            newText += character;
         }
      }

      var result = string.Empty;

      for(int i = 0; i < newText.Length; i++)
      {
         foreach (var letter in alphabet)
         {
            if (newText[i] == letter)
            {
               result += Array.IndexOf(alphabet, letter) + 1;
               if (i != (newText.Length - 1)) result += " ";
            }
         }
      }
      return result;
   }

   // the kata with internet help
   public string AlphabetPositionNew(string text)
   {
      // todo: study string operations (.Replace in this instance)
      text = text.ToUpper().Replace(text, "[^A-Z]"); ;

      var result = string.Empty;
      foreach (var character in text)
      {
         // converts ASCII character to int; A = 65 in ASCII, and so on
         result += (character - 64);
      }
      return result;
   }
}