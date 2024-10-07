namespace Lottery;

public enum WinKind
{
   None,
   FirstPrize,
   SecondPrize,
   ThirdPrize
}

public static class LotteryDraw
{
   public static IReadOnlyCollection<(Person person, WinKind winKind)> GetWinners(IReadOnlyCollection<(Person person, Ticket ticket)> peopleCollection, Ticket winningTicket)
   {
      return GetWinnersImpl(peopleCollection, winningTicket).ToArray();
   }
   //public static List<(Person person, WinKind winKind)> GetWinners
   //   (IReadOnlyCollection<(Person person, Ticket ticket)> peopleCollection, Ticket winningTicket)
   //{
   //   var list = new List<(Person, WinKind)>();
   //   foreach (var (person, ticket) in peopleCollection)
   //   {
   //      var winKind = GetWin(GetMatches(ticket, winningTicket));
   //      if (winKind != WinKind.None)
   //      {
   //         list.Add((person, winKind));
   //      }
   //   }
   //   return list;
   //}

   public static IEnumerable<Person> GetThirdPrizeWinners(IReadOnlyCollection<(Person person, WinKind winKind)> winnerCollection)
   {
      foreach (var (person, winKind) in winnerCollection.Where(p => p.winKind == WinKind.ThirdPrize))
      {
         yield return person;
      }
   }

   public static IEnumerable<Person> GetSecondPrizeWinners(IReadOnlyCollection<(Person person, WinKind winKind)> winnerCollection)
   {
      foreach (var (person, winKind) in winnerCollection.Where(p => p.winKind == WinKind.SecondPrize))
      {
         yield return person;
      }
   }

   public static IEnumerable<Person> GetFirstPrizeWinners(IReadOnlyCollection<(Person person, WinKind winKind)> winnerCollection)
   {
      foreach (var (person, winKind) in winnerCollection.Where(p => p.winKind == WinKind.FirstPrize))
      {
         yield return person;
      }
   }

   private static IEnumerable<(Person person, WinKind winKind)> GetWinnersImpl(IReadOnlyCollection<(Person person, Ticket ticket)> peopleCollection, Ticket winningTicket)
   {
      foreach (var (person, ticket) in peopleCollection)
      {
         var winKind = GetWin(GetMatches(ticket, winningTicket));
         if (winKind != WinKind.None)
         {
            yield return (person, winKind);
         }
      }
   }


   public static WinKind GetWin(int matches)
   {
      switch (matches)
      {
         case 5:
            return WinKind.ThirdPrize;
         case 6:
            return WinKind.SecondPrize;
         case 7: 
            return WinKind.FirstPrize;
         default:
            return WinKind.None;
      }
   }

   public static int GetMatches(Ticket ticket, Ticket winningTicket)
   {
      return ticket.Numbers.Count(i => winningTicket.Numbers.Contains(i));
   }

}