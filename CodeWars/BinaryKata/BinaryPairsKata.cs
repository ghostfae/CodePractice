namespace BinaryKata;

// KATA 2 = INTERLOCKING BINARY PAIRS [7 KYU]
internal class BinaryPairsKata
{
   public static bool Interlockable(ulong a, ulong b)
   {
      throw new NotImplementedException();
   }

   public static bool InterlockableInt(int a, int b)
   {
      a = ToBinaryKata.ToBinary(a);
      b = ToBinaryKata.ToBinary(b);

      while (a > 0 && b > 0)
      {
         if ((a & b) == 1) return false;
         a /= 10;
         b /= 10;
      }
      return true;
   }
}