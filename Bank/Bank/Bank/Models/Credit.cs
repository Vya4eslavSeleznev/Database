namespace Bank.Models
{
  public class Credit
  {
    public int Id { get; }

    public string Name { get; }

    public Credit(int id, string name)
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
