using System.Collections;
using System.Diagnostics;

namespace SnailTwo;

public class SnailEnumerable(int[][] array) : IEnumerable<int>
{
   // state consists: which perimeter is it in
   // what side of perimeter
   // what position of perimeter
   public IEnumerator<int> GetEnumerator()
   {
      return new SnailEnumerator(array);
   }

   IEnumerator IEnumerable.GetEnumerator()
   {
      return GetEnumerator();
   }
}

internal readonly struct SnailEnumerator : IEnumerator<int>, IEnumerator
{
   public SnailEnumerator(int[][] array)
   {
      throw new NotImplementedException();
   }

   public bool MoveNext()
   {
      throw new NotImplementedException();
   }

   public void Reset()
   {
      throw new NotImplementedException();
   }

   public int Current { get; }

   object IEnumerator.Current => Current;

   public void Dispose() { }
}
