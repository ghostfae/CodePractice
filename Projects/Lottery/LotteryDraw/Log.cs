namespace Lottery;

public static class Log
{
   public static void InitialLog(int ticketNumbers, int totalNumbers, int totalPlayers, int allTickets,
      int ticketCost, int maxTicketsPerPerson, int thirdPrizeMoney, int secondPrizeMoney)
   {
      Console.WriteLine($"Lottery draw for {ticketNumbers} out of {totalNumbers}.");
      Console.WriteLine($"We have {totalPlayers} players today, with a whopping total of {allTickets} tickets!");
      Console.WriteLine($"Tickets cost £{ticketCost} each, and you can buy up to {maxTicketsPerPerson} tickets per person!");
      Console.WriteLine($"Our third prize is £{thirdPrizeMoney}, and our second is £{secondPrizeMoney}.");
      Console.WriteLine($"Good luck!");
      Console.WriteLine();
   }

   public static void WinningLog(int firstPrizeTotal, List<Person> firstPrizeWinners, int secondPrizeTotal, int secondPrizeWinners, int thirdPrizeTotal, int thirdPrizeWinners)
   {
      Console.WriteLine($"Main prize winner/s for {firstPrizeTotal:C} each:");
      foreach (var person in firstPrizeWinners)
      {
         Console.WriteLine(person);
      }

      Console.WriteLine();
      Console.WriteLine($"Total second prize spend is {secondPrizeTotal:C}, between {secondPrizeWinners} people");
      Console.WriteLine($"Total third prize spend is {thirdPrizeTotal:C} between {thirdPrizeWinners} people");
   }

   public static void Timer(string process, double timeInSeconds)
   {
      Console.WriteLine($"Time elapsed for {process} is {timeInSeconds}s");
   }
}