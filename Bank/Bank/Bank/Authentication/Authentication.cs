using System;
using System.Windows.Forms;
using System.Data.OleDb;
using Bank.Utils;
using Bank.Exceptions;
using Bank.Models;

namespace Bank
{
  public partial class Authentication : Form
  {
    public Authentication()
    {
      InitializeComponent();
      connection.Open();

      rolesComboBox.Items.Add(new UserRole(0, "Customer"));
      rolesComboBox.Items.Add(new UserRole(1, "Accountant"));
      rolesComboBox.Items.Add(new UserRole(2, "Administrator"));
    }

    private string role()
    {
      return
        "SELECT [Role] " +
        "FROM [User] " +
        "WHERE [Login] = ? AND [Password] = ?";
    }

    private PasswordSaltPair GetOldPasswordSaltPair(string login, int role)
    {
      var query = "SELECT [Password], Salt FROM [User] WHERE [Login] = ? AND [Role] = ?";

      using (var cmd = new OleDbCommand(query, connection))
      {
        cmd.Parameters.Add(new OleDbParameter("@Login", login));
        cmd.Parameters.Add(new OleDbParameter("@Role", role));

        using (var reader = cmd.ExecuteReader())
        {
          if (reader.Read())
            return new PasswordSaltPair(reader.GetString(0), reader.GetString(1));
        }
      }

      throw new InvalidCredentialsException();
    }

    public int GetCustomerId(string login)
    {
      var query = "SELECT CustomerId FROM Customer JOIN [User] ON Customer.UserId = [User].Id WHERE [User].[Login] = ?";

      using (var cmd = new OleDbCommand(query, connection))
      {
        cmd.Parameters.Add(new OleDbParameter("@Login", login));

        using (var reader = cmd.ExecuteReader())
        {
          if (reader.Read())
            return reader.GetInt32(0);
        }
      }

      throw new InvalidCredentialsException();
    }

    private void logInButton_Click(object sender, EventArgs e)
    {
      var login = loginTextBox.Text;
      var password = passwordTextBox.Text;

      if (rolesComboBox.SelectedItem == null || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
      {
        MessageBox.Show("Values are required!", "Authentication", MessageBoxButtons.OK);
        return;
      }

      var roleId = Helpers.GetSelectedId(rolesComboBox);

      try
      {
        var passwordSaltPair = GetOldPasswordSaltPair(login, roleId);

        var credentialsManager = new CredentialsManager();

        if (!credentialsManager.VerifyHashedPassword(passwordSaltPair, password))
          throw new InvalidCredentialsException();

        if (roleId == 0)
        {
          var customerId = GetCustomerId(login);

          var user = new User(customerId, this);
          user.Show();
          Visible = false;
        }
        else if (roleId == 1)
        {
          var accountant = new Accountant(this);
          accountant.Show();
          Visible = false;
        }
        else if (roleId == 2)
        {
          var admin = new Admin(this);
          admin.Show();
          Visible = false;
        }
      } 
      catch(InvalidCredentialsException ex)
      {
        MessageBox.Show(ex.Message, "Authentication", MessageBoxButtons.OK);
        return;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Incorrect parameters!", "Authentication", MessageBoxButtons.OK);
      }
    }

    private void Authentication_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }
  }
}
