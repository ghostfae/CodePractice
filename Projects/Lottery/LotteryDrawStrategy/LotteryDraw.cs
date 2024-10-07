namespace Lottery;

public enum WinKind
{
   None,
   FirstPrize,
   SecondPrize,
   ThirdPrize
}

// strategy-ish
public interface IGetWinners
{
   IReadOnlyCollection<(int id, WinKind winKind)> GetWinners(
      IEnumerable<(int id, Ticket ticket)> peopleCollection, Ticket winningTicket);
}


public class GetWinnersUsingList : IGetWinners
{
   public IReadOnlyCollection<(int id, WinKind winKind)> GetWinners(IEnumerable<(int id, Ticket ticket)> peopleCollection, Ticket winningTicket)
   {
      throw new NotImplementedException();
   }
}

public class GetWinnersUsingYield : IGetWinners
{
   public IReadOnlyCollection<(int id, WinKind winKind)> GetWinners(IEnumerable<(int id, Ticket ticket)> peopleCollection, Ticket winningTicket)
   {
      throw new NotImplementedException();
   }
}


public static class LotteryDraw
{
   public static IReadOnlyCollection<(int id, WinKind winKind)> GetWinners(IReadOnlyCollection<(int id, Ticket ticket)> peopleCollection, Ticket winningTicket)
   {
      return GetWinnersImpl(peopleCollection, winningTicket).ToArray();
   }

   public static IEnumerable<int> GetThirdPrizeWinners(IReadOnlyCollection<(int id, WinKind winKind)> winnerCollection)
   {
      foreach (var (id, winKind) in winnerCollection.Where(p => p.winKind == WinKind.ThirdPrize))
      {
         yield return id;
      }
   }

   public static IEnumerable<int> GetSecondPrizeWinners(IReadOnlyCollection<(int id, WinKind winKind)> winnerCollection)
   {
      foreach (var (id, winKind) in winnerCollection.Where(p => p.winKind == WinKind.SecondPrize))
      {
         yield return id;
      }
   }

   public static IEnumerable<int> GetFirstPrizeWinners(IReadOnlyCollection<(int id, WinKind winKind)> winnerCollection)
   {
      foreach (var (id, winKind) in winnerCollection.Where(p => p.winKind == WinKind.FirstPrize))
      {
         yield return id;
      }
   }

   private static IEnumerable<(int id, WinKind winKind)> GetWinnersImpl(IReadOnlyCollection<(int id, Ticket ticket)> peopleCollection, Ticket winningTicket)
   {
      foreach (var (id, ticket) in peopleCollection)
      {
         var winKind = GetWin(ticket.GetMatches(winningTicket));
         if (winKind != WinKind.None)
         {
            yield return (id, winKind);
         }
      }
   }


   public static WinKind GetWin(int matches)
   {
      switch (matches)
      {
         case 4:
            return WinKind.ThirdPrize;
         case 5:
            return WinKind.SecondPrize;
         case 6: 
            return WinKind.FirstPrize;
         default:
            return WinKind.None;
      }
   }

   //public static int GetMatches(Ticket ticket, Ticket winningTicket)
   //{
   //   return ticket.Numbers.Count(i => winningTicket.Numbers.Contains(i));
   //}

}