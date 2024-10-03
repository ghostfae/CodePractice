namespace SentenceSmash;

internal class Kata
{ 
   public static string Smash(string[] words)
   {
      return string.Join(' ', words);
   }

   public static string SmashLoop(string[] words)
   {
      if (words == null || words.Length == 0)
         return string.Empty;

      string newString = words[0];
      for (int i = 1; i < words.Length; i++)
      { 
         newString += ' ' + words[i];
      }
      return newString;
   }
}