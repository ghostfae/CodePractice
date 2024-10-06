namespace Lottery;

public class LotteryDrawSim (Random random, 
   PersonFactory personFactory, TicketFactory ticketFactory,
   int selectedNumbersAmount, int totalNumbers,
   int totalPlayers, int maxTicketsPerPerson)
{
   public IReadOnlyCollection<(Person person, WinKind winKind)> SimulateDraw
      (List<(Person, Ticket)> players)
   {
      var winningTicket = GenerateTicket();

      return LotteryDraw.GetWinners(players, winningTicket);
   }

   public List<(Person, Ticket)> SimulatePlayers()
   {
      var list = new List<(Person, Ticket)> ();

      var currentPlayers = 0;
      while (currentPlayers < totalPlayers)
      {
         var player = personFactory.GeneratePerson(random);

         var ticketsBought = random.Next(1, maxTicketsPerPerson);
         for (var i = 0; i < ticketsBought; i++)
         {
             list.Add((player, GenerateTicket()));
         }
         currentPlayers++;
      }

      return list;
   }

   private Ticket GenerateTicket()
   {
      return new Ticket(GenerateTicketNumbers());
   }

   private IReadOnlyCollection<int> GenerateTicketNumbers()
   {
      var list = new List<int>();
      while (list.Count < selectedNumbersAmount)
      {
         var number = random.Next(1, totalNumbers);
         if (!list.Contains(number))
         {
            list.Add(number);
         }
      }

      return list;
   }
}