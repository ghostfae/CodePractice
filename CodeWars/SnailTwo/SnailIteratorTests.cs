namespace SnailIterator;

public class SnailIteratorTests
{
   [Test]
   public void ZeroTest()
   {
      IEnumerable<(int, int)> actual = new SnailIterator(0, 0);

      Assert.That(actual, Is.Empty);
   }

   [Test]
   public void ZeroByOne()
   {
      IEnumerable<(int, int)> actual = new SnailIterator(0, 1);

      Assert.That(actual, Is.Empty);
   }

   [Test]
   public void OneByOne()
   {
      var r = new List<(int, int)>
      {
         (0, 0)
      };

      IEnumerable<(int, int)> actual = new SnailIterator(1, 1);

      Assert.That(actual, Is.EqualTo(r));
   }

   [Test]
   public void OneByTwo()
   {
      var r = new List<(int, int)>
      {
         (0, 0), (0, 1)
      };

      IEnumerable<(int, int)> actual = new SnailIterator(1, 2);

      Assert.That(actual, Is.EqualTo(r));
   }

   [Test]
   public void TwoByOne()
   {
      var r = new List<(int, int)>
      {
         (0, 0), (1, 0)
      };

      IEnumerable<(int, int)> actual = new SnailIterator(2, 1);

      Assert.That(actual, Is.EqualTo(r));
   }

   [Test]
   public void TwoByTwo()
   {
      var r = new List<(int, int)>
      {
         (0, 0), (1, 0),
         (1, 1), (0, 1)
      };

      IEnumerable<(int, int)> actual = new SnailIterator(2, 2);

      Assert.That(actual, Is.EqualTo(r));
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

      IEnumerable<(int, int)> actual = new SnailIterator(2, 3);

      Assert.That(actual, Is.EqualTo(r));
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

      IEnumerable<(int, int)> actual = new SnailIterator(3, 2);

      Assert.That(actual, Is.EqualTo(r));
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

      IEnumerable<(int, int)> actual = new SnailIterator(3, 3);

      Assert.That(actual, Is.EqualTo(r));
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
      IEnumerable<(int, int)> actual = new SnailIterator(3, 4);

      Assert.That(actual, Is.EqualTo(r));
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
      IEnumerable<(int, int)> actual = new SnailIterator(4, 3);

      Assert.That(actual, Is.EqualTo(r));
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
      IEnumerable<(int, int)> actual = new SnailIterator(4, 4);

      Assert.That(actual, Is.EqualTo(r));
   }
}