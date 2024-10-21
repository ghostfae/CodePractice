namespace Credit_Card_Mask;

public static class Masker
{
   // return masked string
   public static string Maskify(string cc)
   {
      return cc.Length >= 4 
         ? new string
            ('#', cc.Length - 4) + cc[^4..]
         : cc;
   }

   public static string MaskifyOld(string cc)
   {
      if (cc.Length >= 4)
      {
         var maskLength = cc.Length - 4;

         return new string('#', maskLength) + cc.Substring(maskLength);
      }

      return cc;
   }
}