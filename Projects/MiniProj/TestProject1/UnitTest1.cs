namespace TestProject1
{
   public class Tests
   {
      static bool HasRemainder(int value, int divisor)
      {
         var remainder = value / divisor;
         return (value == remainder * divisor);
      }

      [Test]
      public void TestDivisible()
      {
         Assert.That(HasRemainder(8, 2));
      }

      [Test]
      public void TestNonDivisible()
      {
         Assert.That(!HasRemainder(7, 2));
      }
   }

}