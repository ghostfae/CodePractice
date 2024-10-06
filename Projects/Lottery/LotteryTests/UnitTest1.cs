using Lottery;
namespace LotteryTests;

public class Tests
{
   [Test]
   public void TicketEquality()
   {
      var ticket1 = new Ticket([1, 2, 3]);
      var ticket2 = new Ticket([3, 1, 2]);
      Assert.That(ticket1.Equals(ticket2));
   }

   [Test]
   public void UniqueIds()
   {
      var random = new Random(1);
      var personFactory = new PersonFactory(random);
      var person1 = personFactory.GeneratePerson();
      var person2 = personFactory.GeneratePerson();

      Assert.That(person1.Id != person2.Id);
   }

   [Test]
   public void TicketEqualityMatches()
   {
      var ticket1 = new Ticket([1, 2, 3, 4, 5, 6, 7]);
      var ticket2 = new Ticket([1, 2, 3, 4, 5, 6, 7]);
      var ticket3 = new Ticket([1, 2, 3, 4, 5, 6, 8]);
      var ticket4 = new Ticket([1, 2, 3, 4, 5, 8, 9]);

      int matches1 = LotteryDraw.GetMatches(ticket1, ticket2);
      int matches2 = LotteryDraw.GetMatches(ticket1, ticket3);
      int matches3 = LotteryDraw.GetMatches(ticket1, ticket4);

      Assert.That(matches1 == 7); 
      Assert.That(matches2 == 6); 
      Assert.That(matches3 == 5);
   }

}
