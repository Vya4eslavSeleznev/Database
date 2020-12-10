using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
  class Card
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
