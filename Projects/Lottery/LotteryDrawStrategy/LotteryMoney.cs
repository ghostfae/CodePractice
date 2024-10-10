namespace Lottery;

public class LotteryMoney(
   int ticketCost,
   int totalTickets,
   int thirdPrizeMoney,
   int secondPrizeMoney,
   int thirdPrizeWinners,
   int secondPrizeWinners,
   int firstPrizeWinners)
{
   public int GetMoneyPot()
   {
      return (ticketCost * totalTickets) / 2;
   }

   public int GetFirstPrizePerPerson()
   {
      return GetFirstPrizeMoney() / firstPrizeWinners;
   }

   public int GetThirdPrizeMoney()
   {
      return thirdPrizeMoney * thirdPrizeWinners;
   }

   public int GetSecondPrizeMoney()
   {
      return secondPrizeMoney * secondPrizeWinners;
   }

   public int GetFirstPrizeMoney()
   {
      return GetMoneyPot() - GetThirdPrizeMoney() - GetSecondPrizeMoney();
   }
}