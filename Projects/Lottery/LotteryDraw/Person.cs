namespace LotteryDraw;

public class Person(string firstName, int id)
{
   public string FirstName { get; init; } = firstName;
   public int Id { get; init; } = id;
}

public class PersonFactory(Random random)
{
   private readonly string[] _firstNames =
      ["Anders", "Brad", "Celeste", "Dorothy", "Emmett", "Frankie", "Gigi", "Hannah", "Iris", "John", "Kylie", "Leah", "Marnie", "Ness",
         "Ophelia", "Primm", "Quentin", "Reyna", "Steph", "Tammy", "Uther", "Violet", "Warwick", "Xena", "Yara", "Zoe"];
   private int _id = 0;

   public Person GeneratePerson()
   {
      return new Person(_firstNames[random.Next(1, _firstNames.Length)], _id++);
   }
}