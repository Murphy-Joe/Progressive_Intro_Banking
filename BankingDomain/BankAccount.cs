namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000M;
        private ICalculateBonuses _bonusCalculator;

        public BankAccount(ICalculateBonuses bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
        }

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
         
            decimal bonus = _bonusCalculator.GetBonusForDeposit(_balance, amountToDeposit);

            _balance += amountToDeposit + bonus;
        }
    }
}