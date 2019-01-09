using System;
using Xunit;
using Lab02_UnitTesting;

namespace XUnitTestProject1
{
    public class DepositTests
    {
        [Fact]
        public void CanMakeDeposit()
        {
            Assert.Equal(5100, Program.MakeDeposit(5000, 100));
        }

        [Fact]
        public void CannotMakeNegativeDeposit()
        {
            Assert.Equal(5000, Program.MakeDeposit(5000, -100));
        }
    }

    public class WithdrawalTests
    {
        [Fact]
        public void CanMakeWithdrawal()
        {
            Assert.Equal(4000, Program.MakeWithdrawal(5000, 1000));
        }

        [Fact]
        public void CannotOverdraft()
        {
            Assert.Equal(20, Program.MakeWithdrawal(20, 50));
        }

        [Fact]
        public void CannotMakeNegativeWithdrawal()
        {
            Assert.Equal(5000, Program.MakeWithdrawal(5000, -100));
        }
    }
}
