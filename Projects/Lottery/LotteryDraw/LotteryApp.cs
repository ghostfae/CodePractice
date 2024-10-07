using System.Diagnostics;

namespace Lottery;

internal class LotteryApp
{
   // TO FIND THE SEEDS...
   static void Main(string[] args)
   {
      Console.WriteLine("Starting now...");
      Console.WriteLine();
      var personFactory = new PersonFactory();
      var ticketFactory = new TicketFactory();

      int ticketNumbers = 7;
      int totalNumbers = 49;
      int totalPlayers = 500000;
      int maxTicketsPerPerson = 6;

      var seed = 20;
      bool canContinue = true;

      while (canContinue)
      {
         var random = new Random(seed);

         var sim = new LotteryDrawSim
         (random, personFactory, ticketFactory, ticketNumbers, totalNumbers,
            totalPlayers, maxTicketsPerPerson);

         var allTickets = sim.SimulatePlayers();

         var winningTicket = sim.GenerateTicket();

         var winners = LotteryDraw.GetWinners(allTickets, winningTicket);

         if (seed % 100 == 0)
         {
            Console.WriteLine($"Hit Milestone {seed}");
            Console.WriteLine();
         }

         if (winners.Count(p => p.winKind == WinKind.FirstPrize) > 0)
         {
            Console.WriteLine($"One winner: {seed}");
         }

         if (HasTwoFirstWinners(winners))
         {
            Console.WriteLine($"Two winners: {seed}");
            canContinue = false;
         }

         seed++;
      }

      bool HasTwoFirstWinners(IReadOnlyCollection<(Person person, WinKind winKind)> winners)
      {
         int count = 0;
         foreach (var element in winners)
         {
            if (element.winKind == WinKind.FirstPrize) count++;
         }

         return count >= 2;
      }
   }
}

