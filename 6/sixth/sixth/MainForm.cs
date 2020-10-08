using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sixth
{
  public partial class MainForm : Form
  {
    public int numpage;

    public MainForm()
    {
      InitializeComponent();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (MessageBox.Show(" Хотите выйти?", " Внимание!", MessageBoxButtons.YesNo) == DialogResult.No)
      {
        e.Cancel = true;
      }
    }

    public static string TestString = "";
    private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
    {
      const string Pswd = "QWERTY";
      TestString = TestString + e.KeyChar.ToString().ToUpper();
      this.Text = TestString;
      if (Pswd.Substring(0, TestString.Length) != TestString)
      {
        TestString = "";
      }
      else
      {
        if (Pswd == TestString)
        {
          numpage = 0;
          Form2 secondform = new Form2(this.textBox2.Text, numpage);
          secondform.Show();
          TestString = "";
        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      numpage = -1;
      Form2 secondform = new Form2(this.textBox2.Text, numpage);
      secondform.ShowDialog();
    }
  }
}
