namespace Lottery;

public class LotteryDrawSim (Random random, TicketFactory ticketFactory,
   int selectedNumbersAmount, int totalNumbers,
   int totalPlayers, int maxTicketsPerPerson)
{
   public List<(int, Ticket)> SimulatePlayers()
   {
      var list = new List<(int, Ticket)> ();

      var currentPlayers = 0;
      while (currentPlayers < totalPlayers)
      {
         var ticketsBought = random.Next(1, maxTicketsPerPerson);
         for (var i = 0; i < ticketsBought; i++)
         {
             list.Add((currentPlayers, GenerateTicket()));
         }
         currentPlayers++;
      }

      return list;
   }

   public Ticket GenerateTicket()
   {
      return ticketFactory.GenerateTicket(GenerateTicketNumbers());
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