using Lottery;

namespace LotteryTests;

public class BitmaskTicketTests
{
   [Test]
   public void BitmaskTicketEquality()
   {
      var ticket1 = new BitmaskTicket([1, 2, 3]);
      var ticket2 = new BitmaskTicket([3, 1, 2]);
      Assert.That(ticket1.Equals(ticket2));
   }

   [Test]
   public void BitmaskTicketMatches()
   {
      var ticket1 = new BitmaskTicket([1, 2, 3, 4, 5, 6, 7]);
      var ticket2 = new BitmaskTicket([1, 2, 3, 4, 5, 6, 7]);
      var ticket3 = new BitmaskTicket([1, 2, 3, 4, 5, 6, 8]);
      var ticket4 = new BitmaskTicket([1, 2, 3, 4, 5, 8, 9]);

      int matches1 = ticket1.GetMatches(ticket2);
      int matches2 = ticket1.GetMatches(ticket3);
      int matches3 = ticket1.GetMatches(ticket4);

      Assert.That(matches1 == 7);
      Assert.That(matches2 == 6);
      Assert.That(matches3 == 5);
   }
}