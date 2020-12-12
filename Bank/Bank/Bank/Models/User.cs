namespace Bank.Models
{
  public class User : IEntity
  {
    public int Id { get; }

    public string Name { get; }

    public User(int id, string name)
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
