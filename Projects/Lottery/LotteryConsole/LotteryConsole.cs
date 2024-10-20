using Lottery;
namespace LotteryConsole;

internal class LotteryConsole
{
   private static void Main(string[] args)
   {
      LotteryApp.StartLottery(new SimConfig(), new DrawConfig(), new MoneyConfig());
   }
}