// See https://aka.ms/new-console-template for more information

using System;

public static class Renderer
{}

internal static class Program
{
   private static string ToRandom(this string s)
   {
      return s;
   }

   public static void Main()
   {
      string randomisedPassword = "abc".ToRandom();
      Console.WriteLine(randomisedPassword);
   }
}
