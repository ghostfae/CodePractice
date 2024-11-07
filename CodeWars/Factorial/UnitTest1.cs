namespace Factorial;

public static class Factorial
{
   public static int Get2(int n)
   {
      var product = 1;
      while (n > 0)
      {
         product *= n;
         n--;
      }

      return product;
   }

   public static int Get(int n)
   {
      if (n == 0) return 1;
      return n * Get(n - 1);
   }

}

public class FactorialTests
{
   //[TestCase(0, ExpectedResult = 1)]
   //[TestCase(1, ExpectedResult = 1)]
   //[TestCase(2, ExpectedResult = 2)]
   //[TestCase(3, ExpectedResult = 6)]
   //[TestCase(4, ExpectedResult = 24)]
   //[TestCase(5, ExpectedResult = 120)]
   //[TestCase(6, ExpectedResult = 720)]
   //[TestCase(7, ExpectedResult = 5040)]
   //[TestCase(8, ExpectedResult = 40320)]
   [TestCase(9, ExpectedResult = 362880)]
   public int TestGet(int n)
   {
      return Factorial.Get(n);
   }

}
