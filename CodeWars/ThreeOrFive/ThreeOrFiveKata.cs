namespace ThreeOrFive;

public static class ThreeOrFiveKata
{
	public static int Solution(int value)
   {
      int sum = 0;

      for (int i = 1; i < value; i++)
      {
         if (IsDivisibleByThreeOrFive(i))
         {
            sum += i;
         }
      }
      return sum;
	}

   // function that checks single number for 3 or 5

   private static bool IsDivisibleByThreeOrFive(int value)
   {
      return value % 3 == 0 || value % 5 == 0;
   }
}