namespace BinaryKata;

public class BinaryTests
{
   [Test]
   public void ConvertToBinaryTest()
   {
      Assert.That(ToBinaryKata.ToBinary(1) == 1);
      Assert.That(ToBinaryKata.ToBinary(2) == 10);
      Assert.That(ToBinaryKata.ToBinary(3) == 11);
      Assert.That(ToBinaryKata.ToBinary(5) == 101);
      Assert.That(ToBinaryKata.ToBinary(11) == 1011);
   }

   [Test]
   public void ConvertToDecimalTest()
   {
      Assert.That(ToBinaryKata.ToDecimal(1) == 1);
      Assert.That(ToBinaryKata.ToDecimal(10) == 2);
      Assert.That(ToBinaryKata.ToDecimal(11) == 3);
      Assert.That(ToBinaryKata.ToDecimal(101) == 5);
      Assert.That(ToBinaryKata.ToDecimal(1011) == 11);
   }

   [Test]
   public void InterlockingIntegerTest()
   {
      Assert.True(BinaryPairsKata.InterlockableInt(4, 9));
      Assert.False(BinaryPairsKata.InterlockableInt(3, 6));
   }

   //[Test]
   //public void InterlockingBinaryTest()
   //{
   //   Object[][] tests =
   //   {
   //      new Object[] { true, 9UL, 4UL },
   //      new Object[] { false, 5UL, 6UL },
   //      new Object[] { true, 2UL, 5UL },
   //      new Object[] { false, 7UL, 1UL },
   //      new Object[] { true, 0UL, 8UL }
   //   };
   //   foreach (Object[] test in tests)
   //   {
   //      bool expected = (bool)test[0];
   //      ulong a = (ulong)test[1];
   //      ulong b = (ulong)test[2];
   //      bool submitted = BinaryPairsKata.Interlockable(a, b);
   //      string message = "a = " + a + "\n  b = " + b;
   //      Assert.AreEqual(expected, submitted, message);
   //   }
   //}
}