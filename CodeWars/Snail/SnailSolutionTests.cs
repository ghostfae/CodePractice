public class SnailSolutionTest
{
   [Test]
   public void TwoByTwoTest()
   {
      int[][] array =
      [
         [1, 2],
         [3, 4],
      ];
      var r = new[] { 1, 2, 4, 3 };
      Assert.That(SnailSolution.Snail(array), Is.EqualTo(r));
   }

   [Test]
   public void ThreeByThreeTest()
   {
      int[][] array =
      [
         [1, 2, 3],
         [4, 5, 6],
         [7, 8, 9]
      ];

      var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
      Assert.That(SnailSolution.Snail(array), Is.EqualTo(r));
   }

   [Test]
   public void FourByFourTest()
   {
      int[][] array =
      [
         [1, 2, 3, 4],
         [5, 6, 7, 8],
         [9, 10, 11, 12],
         [13, 14, 15, 16]
      ];

      var r = new[] { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 };
      Assert.That(SnailSolution.Snail(array), Is.EqualTo(r));
   }

   [Test]
   public void OneByOneTest()
   {
      int[][] array =
      [
         [1]
      ];
      var r = new[] { 1 };
      Assert.That(SnailSolution.Snail(array), Is.EqualTo(r));
   }

   [Test]
   public void ZeroByZeroTest()
   {
      int[][] array = [];
      int[] r = [];
      Assert.That(SnailSolution.Snail(array), Is.EqualTo(r));
   }

   [Test]
   public void TwoByOneFails()
   {
      int[][] array =
      [
         [1, 2],
         [3]
      ];

      Assert.Throws<ArgumentException>(() => SnailSolution.Snail(array));
   }
}