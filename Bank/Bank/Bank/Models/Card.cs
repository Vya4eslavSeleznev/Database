namespace Bank.Models
{
  class Card : IEntity
  {
    public int Id { get; }

    public string Number { get; }

    public Card(int id, string number)
    {
      Id = id;
      Number = number;
    }

    public override string ToString()
    {
      return Number;
    }
  }
}
