using LotteryDraw;
namespace LotteryTests;

public class Tests
{
   [Test]
   public void TicketEquality()
   {
      var ticket1 = new Ticket([1, 2, 3]);
      var ticket2 = new Ticket([1, 2, 3]);
      Assert.That(ticket1 == ticket2);
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

}
