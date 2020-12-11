using Bank.Models;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Bank.Utils
{
  public static class Helpers
  {
    public static int GetSelectedId(ComboBox cb)
    {
      return ((IEntity)cb.SelectedItem).Id;
    }

    public static bool TryHandleOleDbException(OleDbException ex)
    {
      if (ex.Errors[0].NativeError != 50000)
        return false;

      MessageBox.Show(ex.Errors[0].Message, "Unexpected error", MessageBoxButtons.OK);
      return true;
    }
  }
}
