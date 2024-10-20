using System.Diagnostics;
using Lottery;
namespace LotteryConsole;

internal class LotteryConsole
{
   static void Main(string[] args)
   {
      //LotteryApp.FindSeed();
      Main1();
   }

   static void Main1()
   {
      Log.StartProgramLog();
      // STOPWATCH
      Stopwatch timer = new Stopwatch();

      // SETUP - creating classes and variables
      var random = new Random(1); // first seed that [4] winners
      var ticketFactory = new TicketFactory();

      int ticketNumbers = 6;
      int totalNumbers = 49;
      int totalPlayers = 10_000_000;
      int maxTicketsPerPerson = 6;

      int ticketCost = 3;
      int thirdPrizeMoney = 10;
      int secondPrizeMoney = 100;

      var sim = new LotteryDrawSim
      (random, ticketFactory, ticketNumbers, totalNumbers,
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
      //var firstPrizeWinners = LotteryDraw.GetFirstPrizeWinners(winners).ToList();

      // LOTTERY PAYMENT
      var money = new LotteryMoney
      (ticketCost, allTickets.Count, thirdPrizeMoney, secondPrizeMoney,
         thirdPrizeWinners.Count, secondPrizeWinners.Count, 0);

      var thirdPrizeTotal = money.GetThirdPrizeMoney();
      var secondPrizeTotal = money.GetSecondPrizeMoney();
      //var firstPrizeTotal = money.GetFirstPrizePerPerson();



      // DISPLAYING VALUES
      Log.WinningLog(0, [], secondPrizeTotal, secondPrizeWinners.Count, thirdPrizeTotal,
         thirdPrizeWinners.Count);

      Log.Timer("Simulation", timer.Elapsed.TotalSeconds);
   }
}