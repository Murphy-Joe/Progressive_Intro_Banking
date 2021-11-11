

using BankingDomain;

namespace BankingKiosk
{
    public partial class Form1 : Form
    {
        private readonly BankAccount _account;
        public Form1()
        {
            InitializeComponent();

            _account = new BankAccount(
                new TimeBasedBonusCalculator(new StandardBusinessClock(new SystemTime())),
                new FakeFedNotifier()
                );

            UpdateBalance();

        }

        private void UpdateBalance()
        {
            Text = $"Your Current Balance is {_account.GetBalance():c}";
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);

        }
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdraw);
        }
        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                var amount = decimal.Parse(txtAmount.Text);

                op(amount); // Delegates!

                UpdateBalance();
                txtAmount.Clear();
                txtAmount.Focus();
            }
            catch (FormatException)
            {

                MessageBox.Show("Enter a number, moron.", "Wow. You are dumb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }

   
    }

    public class FakeFedNotifier : INotifyTheFed
    {
        public void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw)
        {
            MessageBox.Show("The Feds are being Notified");
        }
    }
}