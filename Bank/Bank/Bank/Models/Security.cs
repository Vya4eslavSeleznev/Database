namespace Bank.Models
{
  public class Security : IEntity
  {
    public int Id { get; }

    public string Name { get; }

    public Security(int id, string name)
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
