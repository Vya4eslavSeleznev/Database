using Bank.Models;
using System.Windows.Forms;

namespace Bank.Utils
{
  public static class Helpers
  {
    public static int GetSelectedId(ComboBox cb)
    {
      return ((IEntity)cb.SelectedItem).Id;
    }
  }
}
