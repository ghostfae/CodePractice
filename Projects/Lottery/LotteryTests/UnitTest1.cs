using System;
using System.Diagnostics;
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
      var personFactory = new PersonFactory();
      var person1 = personFactory.GeneratePerson(random);
      var person2 = personFactory.GeneratePerson(random);

      Assert.That(person1.Id != person2.Id);
   }

   [Test]
   public void TicketMatches()
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

   [Test]
   public void TicketDrawSim()
   {
      // SETUP - creating classes and variables
      var random = new Random(17);
      var personFactory = new PersonFactory();
      var ticketFactory = new TicketFactory();

      int ticketNumbers = 7;
      int totalNumbers = 49;
      int totalPlayers = 500000;
      int maxTicketsPerPerson = 6;

      int ticketCost = 3;
      int thirdPrizeMoney = 10;
      int secondPrizeMoney = 100;

      // LOTTERY DRAW SIMULATION
      var sim = new LotteryDrawSim
      (random, personFactory, ticketFactory, ticketNumbers, totalNumbers,
         totalPlayers, maxTicketsPerPerson);

      var allTickets = sim.SimulatePlayers();
      var winners = sim.SimulateDraw(allTickets);

      var thirdPrizeWinners = LotteryDraw.GetThirdPrizeWinners(winners);
      var secondPrizeWinners = LotteryDraw.GetSecondPrizeWinners(winners);
      var firstPrizeWinners = LotteryDraw.GetFirstPrizeWinners(winners);

      // LOTTERY PAYMENT
      var money = new LotteryMoney
         (ticketCost, allTickets.Count, thirdPrizeMoney, secondPrizeMoney,
            thirdPrizeWinners.Count(), secondPrizeWinners.Count(), firstPrizeWinners.Count());

      var thirdPrizeTotal = money.GetThirdPrizeMoney();
      var secondPrizeTotal = money.GetSecondPrizeMoney();
      var firstPrizeTotal = money.GetFirstPrizePerPerson();

      // DISPLAYING VALUES
      Console.WriteLine($"Main prize winner/s for {firstPrizeTotal:C}:");
      foreach (var person in firstPrizeWinners)
      {
         Console.WriteLine(person);
      }

      Console.WriteLine();
      Console.WriteLine($"Total second prize spend is {secondPrizeTotal:C}, between {secondPrizeWinners.Count()} people");
      Console.WriteLine($"Total third prize spend is {thirdPrizeTotal:C} between {thirdPrizeWinners.Count()} people");
   }
}
