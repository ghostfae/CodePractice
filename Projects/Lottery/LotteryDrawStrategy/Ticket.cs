using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lottery;

//public class Ticket_HashSet
//{
//   public IReadOnlyCollection<int> Numbers => _numbers;
//   private readonly HashSet<int> _numbers;

//   public Ticket(IEnumerable<int> numbers)
//   {
//      _numbers = numbers.ToHashSet();
//   }

//   public override bool Equals(object? obj)
//   {
//      if (obj == null || !(obj is Ticket ticket))
//         return false;

//      return _numbers.SetEquals(ticket._numbers);
//   }

//   public override int GetHashCode()
//   {
//      return _numbers.GetHashCode();
//   }


//   public override string ToString()
//   {
//      return string.Join(", ", Numbers);
//   }

//   public int GetMatches(Ticket winningTicket)
//   {
//      return Numbers.Count(i => winningTicket.Numbers.Contains(i));
//   }
//}


public class Ticket
{
   public IReadOnlyCollection<int> Numbers => Enumerate().ToArray();

   private IEnumerable<int> Enumerate()
   {
      for (int i = 0; i < 64; i++)
      {
         if ((_numbers & (1u<<i)) != 0)
         {
            yield return i + 1;
         }
      }
   }

   private readonly ulong _numbers;

   public Ticket(IEnumerable<int> numbers)
   {
      _numbers = 0;
      foreach (var number in numbers)
      {
         _numbers |= 1u<<(number - 1);
      }
   }

   public override bool Equals(object? obj)
   {
      if (obj == null || !(obj is Ticket ticket))
         return false;

      return _numbers.Equals(ticket._numbers);
   }

   public override int GetHashCode()
   {
      return _numbers.GetHashCode();
   }


   public override string ToString()
   {
      return string.Join(", ", Numbers);
   }

   public int GetMatches(Ticket winningTicket)
   {
      return (int) ulong.PopCount(_numbers & winningTicket._numbers);
   }
}
public class TicketFactory
{
   public Ticket GenerateTicket(IReadOnlyCollection<int> numbers)
   {
      return new Ticket(numbers);
   }
}