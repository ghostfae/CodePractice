namespace Credit_Card_Mask
{
   public class Tests
   {
      [Test]
      public void ExamplesTest1()
      {
         Assert.That(Masker.Maskify("4556364607935616") == "############5616");
      }

      [Test]
      public void ExamplesTest2()
      {
         Assert.That(Masker.Maskify("1") == "1");
      }

      [Test]
      public void ExamplesTest3()
      {
         Assert.That(Masker.Maskify("11111") == "#1111");
      }
   }
}