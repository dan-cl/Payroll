using NUnit.Framework;
using Moq;
using Payroll.Employees;
using Payroll.Helpers;

namespace Payroll.Tests
{
    [TestFixture]
    class ManagerTests
    {

        private Mock<IBenefitCalculator> _mockBenefitCalculator;
        private const int PERSONAL_PENSION_PERCENT = 2;

        [Test]
        public void GetTotalCompanyContributions_WhenCalled_ShouldUseTheBenefitCalculatorMethod()
        {
            //Arrange
            _mockBenefitCalculator = new Mock<IBenefitCalculator>();
            var manager = new Manager(PERSONAL_PENSION_PERCENT,
            _mockBenefitCalculator.Object);

            //Act
            manager.GetTotalCompanyContributions();

            //Assert
            _mockBenefitCalculator.Verify(m =>
                m.GetTotalCompanyContributions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>()));
        }

        [Test]
        public void GetTotalPension_WhenCalled_ShouldUseTheBenefitCalculatorMethod()
        {
            //Arrange
            _mockBenefitCalculator = new Mock<IBenefitCalculator>();
            var manager = new Manager(PERSONAL_PENSION_PERCENT,
                _mockBenefitCalculator.Object);

            //Act
            manager.GetTotalPension();

            //Assert
            _mockBenefitCalculator.Verify(m =>
                m.GetTotalPension(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void EmployeeType_WhenCalled_ShouldReturnTheEmployeeType()
        {
            //Arrange
            _mockBenefitCalculator = new Mock<IBenefitCalculator>();
            var manager = new Manager(PERSONAL_PENSION_PERCENT,
                _mockBenefitCalculator.Object);
            var expected = "Manager";

            //Act
            var result = manager.EmployeeType();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
