using BankingDomain;

namespace BankingKiosk;

public partial class Form1 : Form
{
    private readonly BankAccount _acct;
    public Form1()
    {
        InitializeComponent();
        _acct = new BankAccount(
new TimeBasedBonusCalculator(
    new StandardBusinessClock(
        new SystemTime())));

        Text = $"Your Current Balance is {_acct.GetBalance():c}";
    }

    private void btnDeposit_Click(object sender, EventArgs e)
    {
        DoTxn(_acct.Deposit);
    }

    

    private void btnWithdraw_Click(object sender, EventArgs e)
    {
        DoTxn(_acct.Withdraw);

    }

    private void DoTxn(Action<decimal> op)
    {
        try
        {
            var amount = decimal.Parse(txtAmt.Text);

            op(amount);

            Text = $"Your Current Balance is {_acct.GetBalance():c}";
            txtAmt.Clear();
            txtAmt.Focus();
        }
        catch (FormatException)
        {
            MessageBox.Show("Enter a number, moron.", "Wow. You are dumb", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtAmt.SelectAll();
            txtAmt.Focus();
        }
    }
}

//public class FakeFedNotifier : INotifyTheFed
//{
//    public void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw)
//    {
//        MessageBox.Show("The Feds are being Notified");
//    }
//}
