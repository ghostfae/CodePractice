namespace PairwiseMultiplication;

public static class Multiplication
{
   public static IEnumerable<int> GenerateFromSequence(IEnumerable<int> input)
   {
      var inputList = input.ToList();

      var a = inputList.FirstOrDefault(0);

      foreach (var i in inputList.Skip(1))
      {
         yield return a * i;
         a = i;
      }
   }

   public static IEnumerable<int> GenerateFrom1()
   {
      var a = 1;
      var b = 2;

      while (true)
      {
         var c = a * b;
         yield return c;
         a = b;
         b = b + 1;
      }
   }
}

public class Tests
{

   [Test]
   public void Test1()
   {
      var input = new[] { 1, 2, 3, 4 };
      var expected = new [] {2, 6, 12};
      var actual = Multiplication.GenerateFromSequence(input).ToArray();

      CollectionAssert.AreEqual(expected, actual);

      foreach (var i in actual)
      {
         Console.WriteLine(i);
      }
   }
}
