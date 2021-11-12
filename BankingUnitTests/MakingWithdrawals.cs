using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
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
        private readonly BankAccount _account; 
        private readonly decimal _openingBalance;

        public MakingWithdrawals()
        {
            _account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFed>().Object);
            _openingBalance = _account.GetBalance();
        }


        [Fact]
        public void MakingAWithdrawlDecreasesTheBalance()
        {
            // Given
          
            var amountToWithdraw = 100M;
            // When
            _account.Withdraw(amountToWithdraw);
            // Then
            Assert.Equal(
                _openingBalance - amountToWithdraw,
                _account.GetBalance());

        }

        // withdrawing more than I have doesn't change the balance.
        [Fact]
        public void OverdraftDoesntChangeTheBalance()
        {
          
            try
            {
                _account.Withdraw(_openingBalance + .01M);
            }
            catch (CannotOverdraftException)
            {
                // ignoring for this test.
            }
            finally
            {
                Assert.Equal(_openingBalance, _account.GetBalance());
            }

           
        }

        [Fact]
        public void UsersCanWithdrawEntireBalance()
        {
           
            _account.Withdraw(_openingBalance);

            Assert.Equal(0, _account.GetBalance());
        }

        // throw some kind of exception to let the consumer know it didn't work as expected.

        [Fact]
        public void OverdraftThrows()
        {
            


            Assert.Throws<CannotOverdraftException>(() =>
            {
                _account.Withdraw(_openingBalance + 1);
            });
           
        }
    }
}
