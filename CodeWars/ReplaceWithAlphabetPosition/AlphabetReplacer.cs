using System.Text.RegularExpressions;

namespace ReplaceWithAlphabetPosition;

public static class AlphabetReplacer
{
   public static string AlphabetPosition(string text)
   {
      var result = text
         .Select(char.ToUpper)
         .Where(char.IsAsciiLetter)
         .Select(c => c - 'A' + 1)
         .ToArray();
      return string.Join(' ', result);
   }

   public static string AlphabetPosition2(string text)
   {
      var result = new List<int>();

      foreach (var c in text.ToUpper())
      {
         if (c <= 'Z' && c >= 'A')
            result.Add(c - 'A' + 1);
      }

      return string.Join(' ', result);
   }
}