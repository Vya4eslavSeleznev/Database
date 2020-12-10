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
  public partial class MyServices : Form
  {
    private readonly User userForm;
    private int customerId;

    public MyServices(User userForm, int customerId)
    {
      InitializeComponent();
      connection.Open();
      this.userForm = userForm;
      this.customerId = customerId;
      setService();
    }

    private void setService()
    {
      string myServiceQuery =
        "SELECT [Card].Number, CardService.[Name] " +
        "FROM CardService " +
        "JOIN CardServices ON CardService.CardServiceId = CardServices.ServiceId " +
        "JOIN[Card] ON CardServices.CardId = [Card].CardId " +
        "JOIN BalanceCards ON[Card].CardId = BalanceCards.CardId " +
        "JOIN Balance ON Balance.BalanceId = BalanceCards.BalanceId " +
        "WHERE Balance.CustomerId = " + customerId;

      this.userForm.setDataInTable(myServiceQuery, "Service", dsMyServices, myServicesDataGridView);
    }

    private void MyServices_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }
  }
}
