namespace Lottery;

public static class Log
{
   public static void StartProgramLog()
   {
      Console.WriteLine("Starting...");
   }

   public static void InitialLog(DrawConfig lConfig, MoneyConfig mConfig, int allTickets)
   {
      Console.WriteLine($"Lottery draw for {lConfig.TicketNumbers} out of {lConfig.TotalNumbers}.");
      Console.WriteLine($"We have {lConfig.TotalPlayers} players today, with a whopping total of {allTickets} tickets!");
      Console.WriteLine($"Tickets cost £{mConfig.TicketCost} each, and you can buy up to {lConfig.MaxTicketsPerPerson} tickets per person!");
      Console.WriteLine($"Our third prize is £{mConfig.ThirdPrizeMoney}, and our second is £{mConfig.SecondPrizeMoney}.");
      Console.WriteLine($"Good luck!");
      Console.WriteLine();
   }

   public static void WinningLog(int totalPrizeMoney, int firstPrizeTotal, IReadOnlyCollection<int> firstPrizeWinners,
      int secondPrizeTotal, int secondPrizeWinners, int thirdPrizeTotal, int thirdPrizeWinners)
   {
      Console.WriteLine($"Our total money raised has been {totalPrizeMoney}");
      Console.WriteLine();
      Console.WriteLine($"Main prize winner/s for {firstPrizeTotal:C} each:");
      foreach (var id in firstPrizeWinners)
      {
         Console.WriteLine($"Person Id: {id}");
      }
      Console.WriteLine($"For a total of {(firstPrizeTotal * firstPrizeWinners.Count):C}!");
      Console.WriteLine();
      Console.WriteLine($"Total second prize spend is {secondPrizeTotal:C}, between {secondPrizeWinners} people");
      Console.WriteLine($"Total third prize spend is {thirdPrizeTotal:C} between {thirdPrizeWinners} people");
   }

   public static void Timer(string process, double timeInSeconds)
   {
      Console.WriteLine($"Time elapsed for {process} is {timeInSeconds}s");
   }
}