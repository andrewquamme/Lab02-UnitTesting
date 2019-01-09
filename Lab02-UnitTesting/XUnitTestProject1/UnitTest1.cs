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
}
