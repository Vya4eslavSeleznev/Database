using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Bank
{
  public partial class Authentication : Form
  {
    public Authentication()
    {
      InitializeComponent();
      connection.Open();
      rolesComboBox.Items.Add("Customer");
      rolesComboBox.Items.Add("Accountant");
      rolesComboBox.Items.Add("Admin");
    }

    private void logInButton_Click(object sender, EventArgs e)
    {
      if(rolesComboBox.SelectedIndex == 0)
      {
        var login = loginTextBox.Text;
        var password = passwordTextBox.Text;

        string idQuery =
          "SELECT CustomerId " +
          "FROM Customer " +
          "JOIN [User] " +
          "ON Customer.UserId = [User].Id " +
          "WHERE Login = ? AND Password = ?";

        /*string strSQL = "SELECT CustomerId FROM Customer WHERE Customer.UserId =" +
          "(SELECT [User].Id FROM [User] WHERE Login = ? AND Password = ?)";*/

        OleDbCommand cmdIC = new OleDbCommand(idQuery, connection);
        cmdIC.Parameters.Add(new OleDbParameter("@Login", login));
        cmdIC.Parameters.Add(new OleDbParameter("@Password", password));
        OleDbDataReader rdr = cmdIC.ExecuteReader();
        rdr.Read();
        var customerId = Convert.ToInt32(rdr["CustomerId"]);

        var user = new User(customerId);
        user.Show();
        Visible = false;
      }
      else if (rolesComboBox.SelectedIndex == 1)
      {
        var accountant = new Accountant();
        accountant.Show();
        Visible = false;
      }
      else if (rolesComboBox.SelectedIndex == 2)
      {
        var admin = new Admin();
        admin.Show();
        Visible = false;
      }
      else
      {
        MessageBox.Show("Incorrect type of account!", "Authentication", MessageBoxButtons.OK);
      }
    }

    private void Authentication_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }
  }
}
