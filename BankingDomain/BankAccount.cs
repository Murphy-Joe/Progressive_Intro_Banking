namespace BankingDomain
{
    public class BankAccount
    {

        // Class level variables - "Fields"
        private  decimal _balance = 5000M;
        private readonly ICalculateBonuses _bonusCalculator;
        private readonly INotifyTheFed _fedNotifier;
        public BankAccount(ICalculateBonuses bonusCalculator, INotifyTheFed fedNotifier)
        {
            _bonusCalculator = bonusCalculator;
            _fedNotifier = fedNotifier;
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
                // Write the Code You Wish You Had
               _fedNotifier.NotifyOfWithdraw(this, amountToWithdraw);
                _balance -= amountToWithdraw;

            }
        }

        public void Deposit(decimal amountToDeposit)
        {
            // camelCase, PascalCase
            decimal bonus = _bonusCalculator.GetBonusForDeposit(_balance, amountToDeposit);

            _balance += amountToDeposit + bonus;
        }
    }
}