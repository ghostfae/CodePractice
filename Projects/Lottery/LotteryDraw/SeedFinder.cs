using System.Diagnostics;
using System.IO;

namespace Lottery;

internal class SeedFinder
{
   // TO FIND THE SEEDS...
   public static void FindSeed()
   {
      Console.WriteLine("Starting now...");
      Console.WriteLine();

      string docPath = "C:/src/CodePractice/Notes/Projects/Lottery/Winners.txt";

      var personFactory = new PersonFactory();
      var ticketFactory = new TicketFactory();

      int ticketNumbers = 6;
      int totalNumbers = 49;
      int totalPlayers = 10_000_000;
      int maxTicketsPerPerson = 6;

      var seed = 0;
      bool canContinue = true;

      while (canContinue)
      {
         var random = new Random(seed);

         var sim = new LotteryDrawSim
         (random, ticketFactory, ticketNumbers, totalNumbers,
            totalPlayers, maxTicketsPerPerson);

         var allTickets = sim.SimulatePlayers();

         var winningTicket = sim.GenerateTicket();

         var winners = LotteryDraw.GetWinners(allTickets, winningTicket);

         if (seed % 50 == 0)
         {
            Console.WriteLine($"Hit Milestone {seed}");
            Console.WriteLine();
         }

         var firstWinners = FirstWinners(winners);
         if (firstWinners > 1)
         {
            Console.WriteLine($"{firstWinners} winners at seed {seed}");

            using StreamWriter outputFile = File.AppendText(docPath);
            outputFile.WriteLine($"{firstWinners} winners at seed {seed}");
         }

         seed++;
      }

      int FirstWinners(IReadOnlyCollection<(int id, WinKind winKind)> winners)
      {
         int count = 0;
         foreach (var element in winners)
         {
            if (element.winKind == WinKind.FirstPrize) count++;
         }

         return count;
      }
   }
}

