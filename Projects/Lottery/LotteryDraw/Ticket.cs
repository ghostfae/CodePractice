namespace LotteryDraw;

public class Ticket (IReadOnlyCollection<int> numbers)
{
   public readonly IReadOnlyCollection<int> Numbers = numbers;
   public override bool Equals(object? obj)
   {
      if (obj is not Ticket ticket) return false;
      if (ticket == this) return true;

      return Equals(ticket);
   }

   protected bool Equals(Ticket other)
   {
      return Numbers.Equals(other.Numbers);
   }

   public override int GetHashCode()
   {
      return Numbers.GetHashCode();
   }


   public override string ToString()
   {
      return string.Join(", ", Numbers);
   }
}

public class TicketFactory
{
   public Ticket GenerateTicket(IReadOnlyCollection<int> numbers)
   {
      return new Ticket(numbers);
   }
}