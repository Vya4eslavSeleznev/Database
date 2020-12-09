namespace Bank.Models
{
  public class Balance : IEntity
  {
    public int Id { get; }

    public int Number { get; }

    public Balance(int id, int number)
    {
      Id = id;
      Number = number;
    }

    public override string ToString()
    {
      return Number.ToString();
    }
  }
}
