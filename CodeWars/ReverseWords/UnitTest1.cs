namespace ReverseWords
{
   using NUnit.Framework;
   using System;
    
   [TestFixture]
   public class ReverseWordsTests
   {

   [Test]
   public void BasicTests()
   {
      var kata = new ReverseWords();

      Assert.AreEqual("nahsirk", kata.ReverseLetter("krishan"));

      Assert.AreEqual("nortlu", kata.ReverseLetter("ultr53o?n"));

      Assert.AreEqual("cba", kata.ReverseLetter("ab23c"));

      Assert.AreEqual("nahsirk", kata.ReverseLetter("krish21an"));

   }

}
}
