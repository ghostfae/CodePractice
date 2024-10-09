namespace Lottery;

public class LotteryDrawSim (Random random, TicketFactory ticketFactory,
   DrawConfig config)
{
   public List<(int, ITicket)> SimulatePlayers()
   {
      var list = new List<(int, ITicket)> ();

      var currentPlayers = 0;
      while (currentPlayers < config.TotalPlayers)
      {
         var ticketsBought = random.Next(1, config.MaxTicketsPerPerson);
         for (var i = 0; i < ticketsBought; i++)
         {
             list.Add((currentPlayers, GenerateTicket()));
         }
         currentPlayers++;
      }

      return list;
   }

   public ITicket GenerateTicket()
   {
      return ticketFactory.GenerateTicket(GenerateTicketNumbers());
   }

   private IReadOnlyCollection<int> GenerateTicketNumbers()
   {
      var list = new List<int>();
      while (list.Count < config.TicketNumbers)
      {
         var number = random.Next(1, config.TotalNumbers);
         if (!list.Contains(number))
         {
            list.Add(number);
         }
      }

      return list;
   }
}