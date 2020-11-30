using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
  public partial class Accountant : Form
  {
    public Accountant()
    {
      InitializeComponent();
      //connection.Open();
    }

    private void Accountant_FormClosing(object sender, FormClosingEventArgs e)
    {
      //connection.Close();
      Application.Exit();
    }
  }
}
