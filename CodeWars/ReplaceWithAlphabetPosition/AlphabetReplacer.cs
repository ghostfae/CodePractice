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
}