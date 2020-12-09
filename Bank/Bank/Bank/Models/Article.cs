namespace Bank.Models
{
  public class Article : IEntity
  {
    public int Id { get; }

    public string Name { get; }

    public Article(int id, string name)
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
