using System.Numerics;

namespace Fibonacci;

// Create generic?
public static class FibonacciGen
{
   public static IEnumerable<long> Generate(int length)
   {
      return Generate().Take(length);
   }

   public static IEnumerable<long> Generate() // infinite
   {
      var a = 1;
      yield return a;
      var b = 1;
      yield return b;

      while (true)
      {
         var c = a + b;
         yield return c;

         a = b;
         b = c;
      }
      // ReSharper disable once IteratorNeverReturns
   }




   public static IEnumerable<T> Add1<T>(this IEnumerable<T> input) where T : INumber<T>
   {
      return input.Select(i => i + T.CreateChecked(1L));
   }
}

public class Tests
{
   [Test]
   public void TestFloat()
   {
      decimal oneTenth = 1m / 10m;

      Console.WriteLine("\n1/10 as a float: " + oneTenth.ToString("G17"));
      Console.WriteLine("1/10 * 10 as a float: " + (oneTenth * 10).ToString("G17"));
      Console.WriteLine("Expected result: 1");
   }

   [Test]
   public void Test1()
   {
      CollectionAssert.AreEqual(new[] { 2, 2, 3, 4, 6 }, FibonacciGen.Generate(5).Add1());

      CollectionAssert.AreEqual(new []{1, 1, 2, 3, 5}, FibonacciGen.Generate(5));
   }
}
