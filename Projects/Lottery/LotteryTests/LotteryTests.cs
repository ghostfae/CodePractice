using Lottery;

namespace LotteryTests;

public class LotteryTests
{

   [Test]
   public void UniqueIds()
   {
      var random = new Random(1);
      var personFactory = new PersonFactory();
      var person1 = personFactory.GeneratePerson(random);
      var person2 = personFactory.GeneratePerson(random);

      Assert.That(person1.Id != person2.Id);
   }

   [Test]
   public void TicketDrawSim()
   {
      var simConfig = new SimConfig
      {
         TicketKind = TicketKind.Hashset
      };
      var drawConfig = new DrawConfig();
      var moneyConfig = new MoneyConfig();

      LotteryApp.StartLottery(simConfig, drawConfig, moneyConfig);
   }
}