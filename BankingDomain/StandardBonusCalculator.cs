namespace BankingDomain
{
    public class StandardBonusCalculator
    {
        public decimal GetBonusForDeposit(decimal balance, decimal amountOfDeposit)
        {
            // JFHCI
            return balance >= 4000 ? amountOfDeposit * .1M : 0;
        }
    }
}