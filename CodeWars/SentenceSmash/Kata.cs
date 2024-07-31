namespace SentenceSmash;

internal class Kata
{ 
   public static string Smash(string[] words)
   {
      return string.Join(' ', words);
   }

   public static string SmashLoop(string[] words)
   {
      string newString = words[0];
      if (string.IsNullOrEmpty(newString))
         return string.Empty;

      for (int i = 1; i < words.Length; i++)
      { 
         newString += ' ' + words[i];
      }
      return newString;
   }
}