using Lottery;
namespace LotteryTests;

public class HashSetTicketTests
{
   [Test]
   public void HashSetTicketEquality()
   {
      var ticket1 = new HashSetTicket([1, 2, 3]);
      var ticket2 = new HashSetTicket([3, 1, 2]);
      Assert.That(ticket1.Equals(ticket2));
   }

   [Test]
   public void HashSetTicketMatches()
   {
      var ticket1 = new HashSetTicket([1, 2, 3, 4, 5, 6, 7]);
      var ticket2 = new HashSetTicket([1, 2, 3, 4, 5, 6, 7]);
      var ticket3 = new HashSetTicket([1, 2, 3, 4, 5, 6, 8]);
      var ticket4 = new HashSetTicket([1, 2, 3, 4, 5, 8, 9]);

      int matches1 = ticket1.GetMatches(ticket2);
      int matches2 = ticket1.GetMatches(ticket3);
      int matches3 = ticket1.GetMatches(ticket4);

      Assert.That(matches1 == 7);
      Assert.That(matches2 == 6);
      Assert.That(matches3 == 5);
   }
}