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
using Bank.Models;

namespace Bank
{
  public partial class EditCustomer : Form
  {
    private DataRow dRow;
    private DataTable dTable;
    private OleDbDataAdapter dAdapter;
    private readonly int customerId;
    private readonly Admin admin;

    public EditCustomer(int customerId, Admin admin)
    {
      InitializeComponent();
      connection.Open();
      this.customerId = customerId;
      this.admin = admin;
      SetData();
    }

    private void EditCustomer_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      firstNameTextBox.Text = dRow["FirstName"].ToString();
      lastNameTextBox.Text = dRow["LastName"].ToString();
      birthdayTimePicker.Text = dRow["Birthday"].ToString();
      passportNumTextBox.Text = dRow["PassportNum"].ToString();
      phoneTextBox.Text = dRow["Phone"].ToString();
      loginTextBox.Text = dRow["Login"].ToString();
      passwordTextBox.Text = dRow["Password"].ToString();
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var customer =
        "SELECT " +
        "Customer.FirstName, " +
        "Customer.LastName, " +
        "Customer.PassportNum, " +
        "Customer.Birthday, " +
        "Customer.Phone, " +
        "[User].Login, " +
        "[User].Password " +
        "FROM Customer " +
        "JOIN[User] ON Customer.UserId = [User].Id " +
        "WHERE Customer.CustomerId =" + customerId;

      dAdapter = new OleDbDataAdapter(customer, connection);
      dTable = new DataTable();
      dAdapter.Fill(dTable);
    }

    private void SetData()
    {
      FillDataTable();
      ShowRow();
    }

    private void saveChangesButton_Click(object sender, EventArgs e)
    {
      var firstName = firstNameTextBox.Text;
      var lastName = lastNameTextBox.Text;
      var birthday = birthdayTimePicker.Value.Date.ToString("yyyy-MM-dd");
      var passport = passportNumTextBox.Text;
      var phone = phoneTextBox.Text;
      var login = loginTextBox.Text;
      var password = passwordTextBox.Text;

      string customerQuery =
        "";


      using (var cardServiceCmd = new OleDbCommand(customerQuery, connection))
      {
        cardServiceCmd.Parameters.Add(new OleDbParameter("@FirstName", firstName));
        cardServiceCmd.ExecuteNonQuery();
      }

      MessageBox.Show("Customer updated!", "Customer", MessageBoxButtons.OK);
      this.admin.RefreshCardServiceDataGrid();
    }

  }
}
