namespace SentenceSmash;

internal class Kata
{ 
   public static string Smash(string[] words)
   {
      return String.Join(' ', words);
   }

   public static string SmashLoop(string[] words)
   {
      string newString = words[0];
      for (int i = 1; i < words.Length; i++)
      {
         newString += ' ' + words[i];
      }
      return newString;
   }
}