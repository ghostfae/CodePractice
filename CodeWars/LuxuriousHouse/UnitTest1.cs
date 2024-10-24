namespace LuxuriousHouse
{
   public class Tests
   {
      Kata kata = new Kata();

      [Test]
      public void BasicTests1()
      {
         Assert.That(kata.LuxuriousHouse([1, 2, 3, 1, 2]),Is.EqualTo(new[] { 3, 2, 0, 2, 0 }));
      }

      [Test]
      public void BasicTests2()
      {
         Assert.That(kata.LuxuriousHouse([3, 2, 1, 4]), Is.EqualTo(new[] { 2, 3, 4, 0 }));
      }

      [Test]
      public void BasicTests3()
      {
         Assert.That(kata.LuxuriousHouse([2]), Is.EqualTo(new int[] { 0 }));
      }

      [Test]
      public void BasicTests4()
      {
         Assert.That(kata.LuxuriousHouse([1, 2, 3]), Is.EqualTo(new int[] { 3, 2, 0 }));
      }

      [Test]
      public void BasicTests5()
      {
         Assert.That(kata.LuxuriousHouse([3, 2, 1]), Is.EqualTo(new int[] { 0, 0, 0 }));
      }

      [Test]
      public void BasicTests6()
      {
         Assert.That(kata.LuxuriousHouse([1, 1, 1]), Is.EqualTo(new int[] { 1, 1, 0 }));
      }
   }
}