namespace Lottery;

public class Ticket (IReadOnlyCollection<int> numbers)
{
   public readonly IReadOnlyCollection<int> Numbers = numbers;
   public override bool Equals(object? obj)
   {
      if (obj == null || !(obj is Ticket ticket))
         return false;

      return (Numbers == ticket.Numbers);
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