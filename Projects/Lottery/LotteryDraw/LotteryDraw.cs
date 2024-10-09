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
   public static IReadOnlyCollection<(int id, WinKind winKind)> GetWinners(IReadOnlyCollection<(int id, ITicket ticket)> peopleCollection, ITicket winningTicket)
   {
      return peopleCollection
         .Select(t => (t.id, winKind: GetWin(t.ticket.GetMatches(winningTicket))))
         .Where(t => t.winKind != WinKind.None)
         .ToArray();
   }

   public static IReadOnlyCollection<int> GetPrizeWinners(IEnumerable<(int id, WinKind winKind)> winnerCollection, WinKind winKind)
   {
      return winnerCollection
         .Where(t => t.winKind == winKind)
         .Select(t => t.id)
         .ToArray();
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

}