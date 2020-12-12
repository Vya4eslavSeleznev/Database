namespace Bank.Models
{
  public class UserRole : IEntity
  {
    public int Id { get; }

    public string Name { get; }

    public UserRole(int id, string name)
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
