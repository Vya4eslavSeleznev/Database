namespace Bank.Models
{
  public class Deposite
  {
    public int Id { get; }

    public string Name { get; }

    public Deposite(int id, string name)
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
