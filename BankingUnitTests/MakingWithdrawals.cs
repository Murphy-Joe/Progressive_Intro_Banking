using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class MakingWithdrawals
    {

        [Fact]
        public void MakingAWithdrawlDecreasesTheBalance()
        {
            // Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 100M;
            // When
            account.Withdraw(amountToWithdraw);
            // Then
            Assert.Equal(
                openingBalance - amountToWithdraw,
                account.GetBalance());

        }

        // withdrawing more than I have doesn't change the balance.
        [Fact]
        public void OverdraftDoesntChangeTheBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            try
            {
                account.Withdraw(openingBalance + .01M);
            }
            catch (CannotOverdraftException)
            {
                // ignoring for this test.
            }
            finally
            {
                Assert.Equal(openingBalance, account.GetBalance());
            }

           
        }

        [Fact]
        public void UsersCanWithdrawEntireBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            account.Withdraw(openingBalance);

            Assert.Equal(0, account.GetBalance());
        }

        // throw some kind of exception to let the consumer know it didn't work as expected.

        [Fact]
        public void OverdraftThrows()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();


            Assert.Throws<CannotOverdraftException>(() =>
            {
                account.Withdraw(openingBalance + 1);
            });
           
        }
    }
}
