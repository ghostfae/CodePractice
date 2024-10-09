namespace Lottery;

public class LotteryMoney(
   MoneyConfig mConfig,
   int totalTickets,
   int thirdPrizeWinners,
   int secondPrizeWinners,
   int firstPrizeWinners)
{
   public int GetMoneyPot()
   {
      return (mConfig.TicketCost * totalTickets) / 2;
   }

   public int GetFirstPrizePerPerson()
   {
      if (firstPrizeWinners == 0) return 0;
      return GetFirstPrizeMoney() / firstPrizeWinners;
   }

   public int GetThirdPrizeMoney()
   {
      if (thirdPrizeWinners == 0) return 0;
      return mConfig.ThirdPrizeMoney * thirdPrizeWinners;
   }

   public int GetSecondPrizeMoney()
   {
      if (secondPrizeWinners == 0) return 0;
      return mConfig.SecondPrizeMoney * secondPrizeWinners;
   }

   public int GetFirstPrizeMoney()
   {
      return GetMoneyPot() - GetThirdPrizeMoney() - GetSecondPrizeMoney();
   }
}