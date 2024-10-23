namespace ListFiltering;

public static class ListFilterer
{
   public static List<int> GetIntegersFromList(List<object> list)
   {
      return list.OfType<int>().ToList();
   }
   public static List<int> GetIntegersFromList2(List<object> list)
   {
      var newList = new List<int>();

      foreach (var obj in list)
      {
         if (obj is int i)
         {
            newList.Add(i);
         }
      }

      return newList;
   }
}