#pragma warning disable NUnit2005

namespace ThreeOrFive;

[TestFixture]
public class ThreeOrFiveKataTests
{
   [Test]
   public void TestNegative()
   {
      Assertion(expected: 0, input: -5);
   }

   [Test]
   public void TestZero()
   {
      Assertion(expected: 0, input: 0);
   }

   [Test]
   public void SampleTest23()
   {
      Assertion(expected: 23, input: 10);
   }

   [Test]
   public void SampleTest78()
   {
      Assertion(expected: 78, input: 20);
      Assertion(expected: 9168, input: 200);
   }

   private static void Assertion(int expected, int input) =>
      Assert.AreEqual(
         expected,
         ThreeOrFiveKata.Solution(input),
         $"Value: {input}"
      );
}