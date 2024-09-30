namespace SnailTwo;

public class SnailSolutionTests
   {
      [Test]
      public void ZeroTest()
      {
         Assert.That(SnailSolutionV2.Snail(0, 0), Is.Empty);
      }

      [Test]
      public void ZeroByOne()
      {
         Assert.That(SnailSolutionV2.Snail(0, 1), Is.Empty);
      }

      [Test]
      public void OneByOne()
      {
         var r = new List<(int, int)>
         {
            (0, 0)
         };

         Assert.That(SnailSolutionV2.Snail(1, 1), Is.EqualTo(r));
      }

      [Test]
      public void OneByTwo()
      {
      var r = new List<(int, int)>
         {
            (0, 0), (0, 1)
         };

         Assert.That(SnailSolutionV2.Snail(1, 2), Is.EqualTo(r));
      }

      [Test]
      public void TwoByOne()
      {
         var r = new List<(int, int)>
         {
            (0, 0), (1, 0)
         };

         Assert.That(SnailSolutionV2.Snail(2, 1), Is.EqualTo(r));
      }

      [Test]
      public void TwoByTwo()
      {
         var r = new List<(int, int)>
         {
            (0, 0), (1, 0),
            (1, 1), (0, 1)
         };

         Assert.That(SnailSolutionV2.Snail(2, 2), Is.EqualTo(r));
      }

      [Test]
      public void TwoByThree()
      {
         var r = new List<(int, int)>
         {
            (0, 0), (1, 0),
            (1, 1), (1, 2),
            (0, 2), (0, 1)
         };

         Assert.That(SnailSolutionV2.Snail(2, 3), Is.EqualTo(r));
      }
   [Test]
      public void ThreeByTwo()
      {
         int[][] array =
         [
            [1, 2, 3],
            [4, 5, 6],
         ];
         var r = new List<(int, int)>
         {
            (0, 0), (1, 0), (2, 0),
            (2, 1), (1, 1), (0, 1)
         };

         Assert.That(SnailSolutionV2.Snail(3, 2), Is.EqualTo(r));
      }


   [Test]
      public void ThreeByThreeTest()
      {
         var r = new List<(int, int)>
         {
            (0, 0), (1, 0), (2, 0),
            (2, 1), (2, 2), (1, 2),
            (0, 2), (0, 1), (1, 1)
         };

         Assert.That(SnailSolutionV2.Snail(3, 3), Is.EqualTo(r));
      }

      [Test]
      public void ThreeByFourTest()
      {

      var r = new List<(int, int)>
      {
         (0, 0), (1, 0), (2, 0),
         (2, 1), (2, 2), (2, 3),
         (1, 3), (0, 3), (0, 2),
         (0, 1), (1, 1), (1, 2)
      };
      Assert.That(SnailSolutionV2.Snail(3, 4), Is.EqualTo(r));
      }

      [Test]
      public void FourByFourTest()
      {
         var r = new List<(int, int)> 
         {
            (0, 0), (1, 0), (2, 0), (3, 0),
            (3, 1), (3, 2), (3, 3), (2, 3),
            (1, 3), (0, 3), (0, 2), (0, 1),
            (1, 1), (2, 1), (2, 2), (1, 2)
         };
      Assert.That(SnailSolutionV2.Snail(4, 4), Is.EqualTo(r));
      }

      [Test]
      public void FourByThreeTest()
      {
         var r = new List<(int, int)>
         {
            (0, 0), (1, 0), (2, 0), (3, 0),
            (3, 1), (3, 2), (2, 2), (1, 2),
            (0, 2), (0, 1), (1, 1), (2, 1)
         };
      Assert.That(SnailSolutionV2.Snail(4, 3), Is.EqualTo(r));
      }
}