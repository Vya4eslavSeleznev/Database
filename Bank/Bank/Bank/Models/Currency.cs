namespace Bank.Models
{
  public class Currency : IEntity
  {
    public int Id { get; }

    public string Name { get; }

    public Currency(int id, string name)
    {
      Id = id;
      Name = name;
    }

    public override string ToString()
    {
      return Name;
    }
  }
}
