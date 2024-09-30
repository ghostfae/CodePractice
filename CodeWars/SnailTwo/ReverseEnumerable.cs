using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SnailTwo;

public class ReverseEnumerable(int[] array) : IEnumerable<int>
{
   public IEnumerator<int> GetEnumerator()
   {
      return new ReverseEnumerator(array);
   }

   IEnumerator IEnumerable.GetEnumerator()
   {
      return GetEnumerator();
   }
}

internal struct ReverseEnumerator(int[] array) : IEnumerator<int>
{
   public int Current => array[_position];

   private int _position = array.Length;

   public bool MoveNext()
   {
      _position--;
      return _position >= 0;

   }

   public void Reset()
   {
      _position = array.Length;
   }

   object IEnumerator.Current => Current;

   public void Dispose() { }
}
