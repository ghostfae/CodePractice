using System.Numerics;
using System.Text;

namespace Fibonacci;

public static class AggregateHelper
{
   public static int Sum2(this IEnumerable<int> enumerable)
   {
      return enumerable.Aggregate(0, (acc, next) => acc + next);
   }

   public static int Maximum(this IEnumerable<int> enumerable)
   {
      return enumerable.Aggregate((acc, next) => acc < next ? next : acc);
   }

   public static string ConcatenateString(this IEnumerable<string> enumerable, string delimiter)
   {
      var sb = new StringBuilder();
      return enumerable.Aggregate(sb, (acc, next) =>
            acc.Length > 0
               ? acc.Append(delimiter).Append(next)
               : acc.Append(next))
         .ToString();
   }

   public static string ConcatenateString(this IEnumerable<char> enumerable, char delimiter)
   {
      return enumerable.Aggregate(string.Empty, (acc, next) => acc.Length > 0 ? acc + delimiter + next : acc + next);
   }

   public static List<T> InsertAtFront<T>(this List<T> list, T next)
   {
      list.Insert(0, next);
      return list;
   }

   public static IEnumerable<T> Reverse<T>(this IEnumerable<T> enumerable)
   {
      return enumerable.Aggregate(new List<T>(), (acc, next) => acc.InsertAtFront(next));
   }
}


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