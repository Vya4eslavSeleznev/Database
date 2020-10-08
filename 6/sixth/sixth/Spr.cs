using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sixth
{
  class Spr
  {
    int _id;
    string _name;
    public Spr(int id, string name)
    {
      this._id = id;
      this._name = name;
    }
    public string Name
    {
      get
      {
        return this._name;
      }
    }
    public int Id
    {
      get
      {
        return this._id;
      }
    }

    public override string ToString()
    {
      return this._name;
    }
  }
}
