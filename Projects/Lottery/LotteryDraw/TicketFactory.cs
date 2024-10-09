namespace Lottery;

public enum TicketKind
{
   Bitmask,
   Hashset
}

public class TicketFactory(TicketKind kind)
{
   public ITicket GenerateTicket(IReadOnlyCollection<int> numbers)
   {
      return kind switch
      {
         TicketKind.Bitmask => new BitmaskTicket(numbers),
         TicketKind.Hashset => new HashSetTicket(numbers),
         _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
      };
   }
}