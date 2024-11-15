using System.Diagnostics;
using System.Text;

namespace IfElseRedo
{
   public class Percentages(int nBins, char dot, char empty)
   {
      private readonly Dictionary<int, string> _dots = new();

      public string GetPercentage(double percentage)
      {
         percentage = Math.Clamp(percentage, 0.0, 1.0);
         var bin = (int)(percentage * nBins);

         if (!_dots.TryGetValue(bin, out var value))
         {
            value = new string(dot, bin) + new string(empty, nBins - bin);
            _dots[bin] = value;
         }
         return value;
      }
   }

   public class Percentages2(int nBins, char dot, char empty)
   {
      public string GetPercentage(double percentage)
      {
         percentage = Math.Clamp(percentage, 0.0, 1.0);
         var dots = (int)(percentage * nBins);
         return new string(dot, dots) + new string(empty, nBins - dots);
      }
   }


   public class Percentages3(int nBins, char dot, char empty)
   {
      private readonly string[] _dots = GenerateDots(nBins, dot, empty);

      private static string[] GenerateDots(int nBins, char dot, char empty)
      {
         var dots = new string[nBins + 1];
         for (int i = 0; i<=nBins; i++)
            dots[i] = new string(dot, i) + new string(empty, nBins - i);
         return dots;
      }

      public string GetPercentage(double percentage)
      {
         percentage = Math.Clamp(percentage, 0.0, 1.0);
         var bin = (int)(percentage * nBins);
         return _dots[bin];
      }
   }

   public class Percentages4()
   {
      public string GetPercentage(double percentage)
      {
         if (percentage == 0.0) return "OOOOOOOOOO";
         if (percentage <= 0.1) return "XOOOOOOOOO";
         if (percentage <= 0.2) return "XXOOOOOOOO";
         if (percentage <= 0.3) return "XXXOOOOOOO";
         if (percentage <= 0.4) return "XXXXOOOOOO";
         if (percentage <= 0.5) return "XXXXXOOOOO";
         if (percentage <= 0.6) return "XXXXXXOOOO";
         if (percentage <= 0.7) return "XXXXXXXOOO";
         if (percentage <= 0.8) return "XXXXXXXXOO";
         if (percentage <= 0.9) return "XXXXXXXXXO";

         return "XXXXXXXXXX";
      }
   }


   public class Tests
   {
      [Test]
      public void Test1of10()
      {
         Assert.That(new Percentages(10, 'X', 'O').GetPercentage(0.1), Is.EqualTo("XOOOOOOOOO"));
      }

      [Test]
      public void Test1of3()
      {
         Assert.That(new Percentages(3, 'X', 'O').GetPercentage(0.334), Is.EqualTo("XOO"));
      }

      [Test]
      public void Compare()
      {
         var stopWatch = new Stopwatch();

         var random = new Random(1);

         var p1 = new Percentages(10, 'X', 'O');
         var p2 = new Percentages2(10, 'X', 'O');
         var p3 = new Percentages3(10, 'X', 'O'); 
         var p4 = new Percentages4();

         var n = 1000000;

         stopWatch.Start();
         for (int i = 0; i < n; i++)
         {
            p1.GetPercentage((double)random.Next(0, 10)/10);
         }
         stopWatch.Stop();
         var t1 = stopWatch.ElapsedMilliseconds;
         stopWatch.Reset();

         stopWatch.Start();
         for (int i = 0; i < n; i++)
         {
            p2.GetPercentage((double)random.Next(0, 10) / 10);
         }
         stopWatch.Stop();
         var t2 = stopWatch.ElapsedMilliseconds;
         stopWatch.Reset();

         stopWatch.Start();
         for (int i = 0; i < n; i++)
         {
            p3.GetPercentage((double)random.Next(0, 10) / 10);
         }
         stopWatch.Stop();
         var t3 = stopWatch.ElapsedMilliseconds;
         stopWatch.Reset();

         stopWatch.Start();
         for (int i = 0; i < n; i++)
         {
            p4.GetPercentage((double)random.Next(0, 10) / 10);
         }
         stopWatch.Stop();
         var t4 = stopWatch.ElapsedMilliseconds;

         Console.WriteLine($"t1 = {t1}");
         Console.WriteLine($"t2 = {t2}");
         Console.WriteLine($"t3 = {t3}");
         Console.WriteLine($"t4 = {t4}");
      }
   }
}