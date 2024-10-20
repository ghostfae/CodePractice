namespace Lottery;
public class DrawConfig
{
   public int TicketNumbers { get; set; } = 6;
   public int TotalNumbers { get; set; } = 49;
   public int TotalPlayers { get; set; } = 10_000_000;
   public int MaxTicketsPerPerson { get; set; } = 6;
}

public class MoneyConfig
{
   public int TicketCost { get; set; } = 3;
   public int ThirdPrizeMoney { get; set; } = 10;
   public int SecondPrizeMoney { get; set; } = 100;
}

public class SimConfig
{
   public int Seed { get; set; } = 2;
   public TicketKind TicketKind { get; set; } = TicketKind.Bitmask;
}