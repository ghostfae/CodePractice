namespace SnailTwo;

public class SnailEnumerableTests
{
   [Test]
   public void ThreeByThreeTest()
   {
      int[][] input =
      [
         [1, 2, 3],
         [4, 5, 6],
         [7, 8, 9]
      ];

      var expected = new[]
      {
         1, 2, 3, 6, 9, 8, 7, 4, 5
      };

      IEnumerable<int> actual = new SnailEnumerable(input);

      Assert.That(actual, Is.EqualTo(expected));
   }
}