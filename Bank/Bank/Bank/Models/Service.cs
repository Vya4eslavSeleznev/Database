﻿namespace Bank.Models
{
  class Service : IEntity
  {
    public int Id { get; }

    public string Name { get; }

    public Service(int id, string name)
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
