using System;
using Xunit;
using Lab02_UnitTesting;

namespace XUnitTestProject1
{
    public class NumberValidationTests
    {
        [Fact]
        public void CannotEnterLetters()
        {
            Assert.Equal(0, Program.CheckValidNumbers("x"));
        }

        [Fact]
        public void CannotEnterBlank()
        {
            Assert.Equal(0, Program.CheckValidNumbers(""));
        }
    }

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

        [Fact]
        public void CannotMakeLargeDeposit()
        {
            Assert.Equal(5000, Program.MakeDeposit(5000, 5001));
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

        [Fact]
        public void CannotMakeLargeWithdrawals()
        {
            Assert.Equal(6000, Program.MakeWithdrawal(6000, 5001));
        }
    }
}
