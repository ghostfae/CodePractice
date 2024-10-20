using System.Net.Sockets;

namespace Lottery;

public class BitmaskTicket : ITicket
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

   public BitmaskTicket(IEnumerable<int> numbers)
   {
      _numbers = 0;
      foreach (var number in numbers)
      {
         _numbers |= 1u<<(number - 1);
      }
   }

   public override bool Equals(object? obj)
   {
      return obj is BitmaskTicket other && Equals(other);
   }
   private bool Equals(BitmaskTicket other)
   {
      return _numbers.Equals(other._numbers);
   }

   public override int GetHashCode()
   {
      return _numbers.GetHashCode();
   }


   public override string ToString()
   {
      return string.Join(", ", Numbers);
   }

   public int GetMatches(ITicket winningTicket)
   {
      var winningNumbers = ((BitmaskTicket) winningTicket)._numbers;
      return (int) ulong.PopCount(_numbers & winningNumbers);
   }
}