namespace Fibonacci;

// Create generic?

public class Tests
{
   [Test]
   public void TestFloat()
   {
      decimal oneTenth = 1m / 10m;

      Console.WriteLine("\n1/10 as a float: " + oneTenth.ToString("G17"));
      Console.WriteLine("1/10 * 10 as a float: " + (oneTenth * 10).ToString("G17"));
      Console.WriteLine("Expected result: 1");
   }

   [Test]
   public void Test1()
   {
      CollectionAssert.AreEqual(new[] { 2, 2, 3, 4, 6 }, FibonacciGen.Generate(5).Add1());

      CollectionAssert.AreEqual(new []{1, 1, 2, 3, 5}, FibonacciGen.Generate(5));
   }

   [Test]
   public void SumTest()
   {
      var values = new[] { 1, 2, 3, 4, 5 };
      var expected = 15;

      Assert.That(values.Sum2(), Is.EqualTo(expected));
   }

   [Test]
   public void MaximumTest()
   {
      var values = new[] { 1, 2, 3, 4, 5, 3, -1, 0 };
      var expected = 5;

      Assert.That(values.Maximum(), Is.EqualTo(expected));
   }

   [Test]
   public void ConcatenateTest()
   {
      var values = new[] { "hi", "hello", "hey" };
      var delimiter = ", ";
      var expected = "hi, hello, hey";

      Assert.That(values.ConcatenateString(delimiter), Is.EqualTo(expected));
   }

   [Test]
   public void ConcatenateTest2()
   {
      var values = new[] { 'h', 'e', 'y' };
      var delimiter = ',';
      var expected = "h,e,y";

      Assert.That(values.ConcatenateString(delimiter), Is.EqualTo(expected));
   }

   [Test]
   public void ReverseNumTest()
   {
      var values = new[] { 1, 2, 3, 5, 7 };
      var expected = new[] { 7, 5, 3, 2, 1 };

      Assert.That(values.Reverse(), Is.EqualTo(expected));
   }

   [Test]
   public void ReverseStringTest()
   {
      var values = new[] { "a", "b", "c", "d" };
      var expected = new[] {"d", "c", "b", "a"};

      Assert.That(values.Reverse(), Is.EqualTo(expected));
   }
}
