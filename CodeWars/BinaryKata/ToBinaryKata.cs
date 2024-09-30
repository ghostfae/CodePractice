namespace BinaryKata;

// KATA 1 - CONVERT TO BINARY [8KYU]
internal class ToBinaryKata
{
   private const int MaximumRepresentableInteger = 0b_111_111_111; // this is the largest 32bit integer that c# can handle expressed as binary
   private const int MaxDigits = 10; // as above, this is the amount of decimal spaces that the maximum integer has

   public static int ToBinary2(int value)
   {
      if (value < 0 || value > MaximumRepresentableInteger)
         throw new ArgumentOutOfRangeException(nameof(value));

      int result = 0;
      int decimalMask = 1;
      for (int i = 0; i < MaxDigits; i++, decimalMask *= 10)
      {
         if ((value & (1 << i)) != 0)
         {
            result += decimalMask;
         }
      }

      return result;
   }

   public static int ToBinary(int value)
   {
      if (value < 0 || value > MaximumRepresentableInteger)
         throw new ArgumentOutOfRangeException(nameof(value));

      int result = 0;
      int decimalMask = 1;
      while (value != 0)
      {
         result += decimalMask * (value & 1);
         value /= 2;
         decimalMask *= 10;
      }

      return result;
   }

   public static int ToDecimal2(int value)
   {
      int result = 0;
      int i = 0;

      while (value > 0)
      {
         if (value % 2 == 1)
            result += (1 << i);

         value /= 10;
         i++;
      }

      return result;
   }

   public static int ToDecimal(int value)
   {
      int result = 0;
      int mask = 1;
       
      while (value > 0)
      {
         //result += mask * (value % 2);
         result += mask * (value & 1);
         value /= 10;
         mask *= 2;
      }

      return result;
   }

   public static int ToDecimal3(int value)
   {
      int result = 0;
      for (int mask = 1; value > 0; value /= 10, mask *= 2) result += mask * (value % 2);
      return result;
   }
}