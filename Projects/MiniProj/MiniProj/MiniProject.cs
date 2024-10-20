   static bool HasRemainder(int value, int divisor)
   {
      var remainder = value / divisor;
      return (value == remainder * divisor);
   }
