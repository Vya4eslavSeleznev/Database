﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
  class Service
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