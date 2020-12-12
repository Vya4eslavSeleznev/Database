﻿using System;
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

    private string role()
    {
      return
        "SELECT [Role] " +
        "FROM [User] " +
        "WHERE [Login] = ? AND [Password] = ?";
    }

    private void logInButton_Click(object sender, EventArgs e)
    {
      var login = loginTextBox.Text;
      var password = passwordTextBox.Text;

      if (rolesComboBox.SelectedIndex == 0)
      {
        string idQuery =
          "SELECT CustomerId " +
          "FROM Customer " +
          "JOIN [User] " +
          "ON Customer.UserId = [User].Id " +
          "WHERE [Login] = ? AND [Password] = ?";

        OleDbCommand cmdIC = new OleDbCommand(idQuery, connection);
        cmdIC.Parameters.Add(new OleDbParameter("@Login", login));
        cmdIC.Parameters.Add(new OleDbParameter("@Password", password));
        OleDbDataReader rdr = cmdIC.ExecuteReader();
        rdr.Read();

        try
        {
          var customerId = Convert.ToInt32(rdr["CustomerId"]);
          var user = new User(customerId);
          user.Show();
          Visible = false;
        }
        catch (Exception ex)
        {
          MessageBox.Show("Incorrect parameters!", "Authentication", MessageBoxButtons.OK);
        }
      }
      else
      {
        string roleQuery = role();
        OleDbCommand cmdIC = new OleDbCommand(roleQuery, connection);
        cmdIC.Parameters.Add(new OleDbParameter("@Login", login));
        cmdIC.Parameters.Add(new OleDbParameter("@Password", password));
        OleDbDataReader rdr = cmdIC.ExecuteReader();
        rdr.Read();

        try
        {
          var role = Convert.ToInt32(rdr["Role"]);

          if (role == 1)
          {
            var accountant = new Accountant();
            accountant.Show();
            Visible = false;
          }
          else if (role == 2)
          {
            var admin = new Admin();
            admin.Show();
            Visible = false;
          }
          else
          {
            MessageBox.Show("Incorrect type of account!", "Authentication", MessageBoxButtons.OK);
            return;
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Incorrect parameters!", "Authentication", MessageBoxButtons.OK);
        }
      }
    }

    private void Authentication_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }
  }
}
