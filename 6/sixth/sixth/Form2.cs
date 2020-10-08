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
  public partial class Form2 : Form
  {
    public Form2(string strParam, int page)
    {
      InitializeComponent();
      this.txtGetText.Text = strParam;
      numpag = page;
    }

    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
      textBox1.Text = listBox1.SelectedItem.ToString();
      textBox2.Text = listBox1.SelectedIndex.ToString();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      foreach (object item in listBox1.SelectedItems)
      {
        richTextBox1.Text = richTextBox1.Text + item.ToString() + "\r\n";
      }
      foreach (object item in listBox1.SelectedIndices)
      {
        richTextBox2.Text = richTextBox2.Text + item.ToString() + "\r\n";
      }

    }

    public int numpag;
    private void Form2_Load(object sender, EventArgs e)
    {
      if (numpag == 0)
      {
        this.tabControl1.SelectedTab = this.tabPage1;
      }
      else if (numpag == -1)
      {
        this.tabControl1.SelectedTab = this.tabPage2;

        comboBox1.Items.Add(new Spr(1, "Ваня"));
        comboBox1.Items.Add(new Spr(2, "Ваcя"));
        comboBox1.Items.Add(new Spr(3, "Петя"));
        comboBox1.Items.Add(new Spr(4, "Гоша"));
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      MessageBox.Show(((Spr)comboBox1.SelectedItem).Id.ToString());
    }
  }
}
