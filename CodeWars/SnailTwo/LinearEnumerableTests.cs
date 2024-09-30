namespace SnailTwo;

public class ReverseEnumerableTests
{
   [Test]
   public void Test123()
   {
      int[] input =
      [
         1, 2, 3
      ];

      var expected = new[]
      {
         3, 2, 1
      };

      IEnumerable<int> actual = new ReverseEnumerable(input);

      Assert.That(actual, Is.EqualTo(expected));
   }
}