namespace Lottery;

public class Ticket
{
   public IReadOnlyCollection<int> Numbers => _numbers;
   private readonly HashSet<int> _numbers;

   public Ticket(IEnumerable<int> numbers)
   {
      _numbers = numbers.ToHashSet();
   }

   public override bool Equals(object? obj)
   {
      if (obj == null || !(obj is Ticket ticket))
         return false;

      return _numbers.SetEquals(ticket._numbers);
   }

   public override int GetHashCode()
   {
      return _numbers.GetHashCode();
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