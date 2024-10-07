using System.Collections.Generic;
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
      var random = new Random(1122); // first seed that has two winners
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
      Log.InitialLog(ticketNumbers, totalNumbers, totalPlayers, allTickets.Count,
         ticketCost, maxTicketsPerPerson, thirdPrizeMoney, secondPrizeMoney);

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
      Log.WinningLog(firstPrizeTotal, firstPrizeWinners, secondPrizeTotal, secondPrizeWinners.Count, thirdPrizeTotal, thirdPrizeWinners.Count);

      Log.Timer("Simulation", timer.Elapsed.TotalSeconds);
   }
}