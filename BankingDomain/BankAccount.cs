namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000M;
        public decimal GetBalance()
        {
            return _balance;
           
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _balance)
            {
                throw new CannotOverdraftException();
            }
            else
            {
                _balance -= amountToWithdraw;
            }
        }

        public void Deposit(decimal amountToDeposit)
        {
            
            _balance += amountToDeposit;
        }
    }
}