using System.Net.Sockets;

namespace Lottery;

public interface ITicket
{
   IReadOnlyCollection<int> Numbers { get; }

   int GetMatches(ITicket winningTicket);
}

public class HashSetTicket(IEnumerable<int> numbers) : ITicket
{
   public IReadOnlyCollection<int> Numbers => _numbers;
   private readonly HashSet<int> _numbers = numbers.ToHashSet();

   public override bool Equals(object? obj)
   {
      return obj is HashSetTicket other && Equals(other);
   }

   private bool Equals(HashSetTicket other)
   {
      return _numbers.SetEquals(other._numbers);
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
      return Numbers.Count(i => winningTicket.Numbers.Contains(i));
   }
}
