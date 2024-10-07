using System.Diagnostics;
using Lottery;
namespace LotteryConsole;

internal class LotteryConsole
{
   static void Main(string[] args)
   {
      // STOPWATCH
      Stopwatch timer = new Stopwatch();
      

      // SETUP - creating classes and variables
      var random = new Random(1122);
      var personFactory = new PersonFactory();
      var ticketFactory = new TicketFactory();

      int ticketNumbers = 7;
      int totalNumbers = 49;
      int totalPlayers = 1000000;
      int maxTicketsPerPerson = 6;

      int ticketCost = 3;
      int thirdPrizeMoney = 10;
      int secondPrizeMoney = 100;

      var sim = new LotteryDrawSim
      (random, personFactory, ticketFactory, ticketNumbers, totalNumbers,
         totalPlayers, maxTicketsPerPerson);

      var allTickets = sim.SimulatePlayers();

      // CONSOLE INITIALISATION
      Console.WriteLine($"Lottery draw for {ticketNumbers} out of {totalNumbers}.");
      Console.WriteLine($"We have {totalPlayers} players today, with a whopping total of {allTickets.Count} tickets!");
      Console.WriteLine($"Tickets cost £{ticketCost} each, and you can buy up to {maxTicketsPerPerson} tickets per person!");
      Console.WriteLine($"Our third prize is £{thirdPrizeMoney}, and our second is £{secondPrizeMoney}.");
      Console.WriteLine($"Good luck!");
      Console.WriteLine();

      // LOTTERY DRAW SIMULATION
      var winningTicket = sim.GenerateTicket();

      timer.Start();

      var winners = LotteryDraw.GetWinners(allTickets, winningTicket);
      timer.Stop();

      var thirdPrizeWinners = LotteryDraw.GetThirdPrizeWinners(winners).ToList();
      var secondPrizeWinners = LotteryDraw.GetSecondPrizeWinners(winners).ToList();
      var firstPrizeWinners = LotteryDraw.GetFirstPrizeWinners(winners).ToList();

      // LOTTERY PAYMENT
      var money = new LotteryMoney
      (ticketCost, allTickets.Count, thirdPrizeMoney, secondPrizeMoney,
         thirdPrizeWinners.Count, secondPrizeWinners.Count, firstPrizeWinners.Count);

      var thirdPrizeTotal = money.GetThirdPrizeMoney();
      var secondPrizeTotal = money.GetSecondPrizeMoney();
      var firstPrizeTotal = money.GetFirstPrizePerPerson();
      


      // DISPLAYING VALUES
      Console.WriteLine($"Main prize winner/s for {firstPrizeTotal:C} each:");
      foreach (var person in firstPrizeWinners)
      {
         Console.WriteLine(person);
      }

      Console.WriteLine();
      Console.WriteLine($"Total second prize spend is {secondPrizeTotal:C}, between {secondPrizeWinners.Count()} people");
      Console.WriteLine($"Total third prize spend is {thirdPrizeTotal:C} between {thirdPrizeWinners.Count()} people");

      var process = "Sim";
      var ts = timer.Elapsed.TotalSeconds;

      Console.WriteLine($"Time elapsed for {process} is {ts}s");
   }
}