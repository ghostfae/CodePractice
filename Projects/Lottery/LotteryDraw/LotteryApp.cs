using System.Diagnostics;
namespace Lottery;

public static class LotteryApp
{
   public static void StartLottery(SimConfig simConfig, DrawConfig drawConfig, MoneyConfig moneyConfig)
   {
      Log.StartProgramLog();
      // STOPWATCH
      Stopwatch timer = new Stopwatch();

      // SETUP - creating classes and variables
      var random = new Random(simConfig.Seed); // first seed that [4] winners
      var ticketFactory = new TicketFactory(simConfig.TicketKind);

      var sim = new LotteryDrawSim
         (random, ticketFactory, drawConfig);

      var allTickets = sim.SimulatePlayers();

      // CONSOLE INITIALISATION
      Log.InitialLog(drawConfig, moneyConfig, allTickets.Count);

      // LOTTERY DRAW SIMULATION
      var winningTicket = sim.GenerateTicket();

      timer.Start();

      var winners = LotteryDraw.GetWinners(allTickets, winningTicket);
      timer.Stop();

      var thirdPrizeWinners = LotteryDraw.GetPrizeWinners(winners, WinKind.ThirdPrize);
      var secondPrizeWinners = LotteryDraw.GetPrizeWinners(winners, WinKind.SecondPrize);
      var firstPrizeWinners = LotteryDraw.GetPrizeWinners(winners, WinKind.FirstPrize);

      // LOTTERY PAYMENT
      var money = new LotteryMoney
      (moneyConfig, allTickets.Count,
         thirdPrizeWinners.Count, secondPrizeWinners.Count, firstPrizeWinners.Count);

      var moneyTotal = money.GetMoneyPot();
      var thirdPrizeTotal = money.GetThirdPrizeMoney();
      var secondPrizeTotal = money.GetSecondPrizeMoney();
      var firstPrizeTotal = money.GetFirstPrizePerPerson();

      // DISPLAYING VALUES
      Log.WinningLog(moneyTotal, firstPrizeTotal, firstPrizeWinners, secondPrizeTotal, secondPrizeWinners.Count, thirdPrizeTotal,
         thirdPrizeWinners.Count);

      Log.Timer("Simulation", timer.Elapsed.TotalSeconds);
   }

   public static void FindSeed()
   {
      Console.WriteLine("Starting now...");
      Console.WriteLine();

      const string docPath = "C:/src/CodePractice/Notes/Projects/Lottery/Winners.txt";

      var sConfig = new SimConfig();
      var ticketFactory = new TicketFactory(sConfig.TicketKind);

      var seed = 0;
      var canContinue = true;

      while (canContinue)
      {
         var random = new Random(seed);

         var sim = new LotteryDrawSim
            (random, ticketFactory, new DrawConfig());

         var allTickets = sim.SimulatePlayers();

         var winningTicket = sim.GenerateTicket();

         var winners = LotteryDraw.GetWinners(allTickets, winningTicket);

         if (seed % 50 == 0)
         {
            Console.WriteLine($"Hit Milestone {seed}");
            Console.WriteLine();
         }

         var firstWinners = winners.Count(t => t.winKind == WinKind.FirstPrize);
         if (firstWinners > 1)
         {
            var winLog = $"{firstWinners} winners at seed {seed}";
            Console.WriteLine(winLog);
            using var outputFile = File.AppendText(docPath);
            outputFile.WriteLine(winLog);
         }

         if (seed >= 1000)
            canContinue = false;

         seed++;
      }
   }
}