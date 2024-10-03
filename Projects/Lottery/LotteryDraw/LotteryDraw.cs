using System.Collections.Generic;

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
   public static List<(Person person, WinKind winKind)> GetWinners(IReadOnlyCollection<(Person person, Ticket ticket)> peopleCollection, Ticket winningTicket)
   {
      var winners = new List<(Person person, WinKind winKind)>();

      foreach (var (person, ticket) in peopleCollection)
      {
         var winKind = GetWin(GetMatches(ticket, winningTicket));
         if (winKind != WinKind.None)
         {
            winners.Add((person, winKind));
         }
      }

      return winners;
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