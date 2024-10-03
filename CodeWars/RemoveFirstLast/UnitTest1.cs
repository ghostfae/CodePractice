namespace RemoveFirstLast
{
   public class Tests
   {
      [SetUp]
      public void Setup()
      {
      }

      [Test]
      public void Test1()
      {
         StringAssert.AreEqualIgnoringCase("loquen", Kata.RemoveChar("eloquent"));
         StringAssert.AreEqualIgnoringCase("ountr", Kata.RemoveChar("country"));
         StringAssert.AreEqualIgnoringCase("erso", Kata.RemoveChar("person"));
         StringAssert.AreEqualIgnoringCase("lac", Kata.RemoveChar("place"));
         StringAssert.AreEqualIgnoringCase("", Kata.RemoveChar("ok"));
      }
   }
}