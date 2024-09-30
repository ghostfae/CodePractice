using SnailTwo;
using System.Collections;
using System.Security.Cryptography;

namespace SnailIterator;

public class SnailIterator(int columns, int rows) : IEnumerable<(int, int)>
{
   public IEnumerator<(int, int)> GetEnumerator()
   {
      return new SnailEnumerator(columns, rows);
   }

   IEnumerator IEnumerable.GetEnumerator()
   {
      return GetEnumerator();
   }
}

internal class SnailEnumerator(int width, int height) : IEnumerator<(int, int)>
{
   private enum Side
   {
      Undefined,
      Top,
      Right,
      Bottom,
      Left
   }

   private Side _side = Side.Undefined;
   private int _x;
   private int _y;
   private int _depth;
   public (int, int) Current => (_x, _y);

   public bool MoveNext()
   {
      if (ShouldSwitchSide()) 
         return SwitchSide();

      Increment();
      return true;
   }

   private void Increment()
   {
      switch (_side)
      {
         case Side.Top:
            _x++;
            break;
         case Side.Right:
            _y++;
            break;
         case Side.Bottom:
            _x--;
            break;
         case Side.Left:
            _y--;
            break;
         default:
            throw new ArgumentOutOfRangeException();
      }
   }

   private bool SwitchSide()
   {
      switch (_side)
      {
         case Side.Undefined:
            _x = 0;
            _y = 0;
            _depth = 0;
            _side = Side.Top;
            return true;
         case Side.Top:
            _side = Side.Right;
            return true;
         case Side.Right:
            _side = Side.Bottom;
            return true;
         case Side.Bottom:
            _side = Side.Left;
            return true;
         case Side.Left:
            _side = Side.Top;
            _depth++;
            _x = _depth;
            _y = _depth;
            return _depth * 2 <= Math.Min(width, height);
         default:
            throw new ArgumentOutOfRangeException();
      }
   }

   private bool ShouldSwitchSide()
   {
      return _side switch
      {
         Side.Undefined => true,
         Side.Top => _x >= width - _depth - 1,
         Side.Right => _y >= height - _depth - 1,
         Side.Bottom => _x <= _depth,
         Side.Left => _y <= _depth,
         _ => throw new ArgumentOutOfRangeException()
      };
   }

   public void Reset()
   {
      _side = Side.Undefined;
   }

   object IEnumerator.Current => Current;

   public void Dispose()
   {
   }
}