using NUnit.Framework;
using Moq;
using Payroll.Employees;
using Payroll.Helpers;

namespace Payroll.Tests
{
    [TestFixture]
    class ExecutiveTests
    {

        private Mock<IBenefitCalculator> _mockBenefitCalculator;
        private Mock<ICompanyPensionContributionHelper> _mockCompanyPensionContributionHelper;
        private const int PERSONAL_PENSION_PERCENT = 2;

        [Test]
        public void GetTotalCompanyContributions_WhenCalled_ShouldUseTheBenefitCalculatorMethod()
        {
            //Arrange
            _mockBenefitCalculator = new Mock<IBenefitCalculator>();
            _mockCompanyPensionContributionHelper = new Mock<ICompanyPensionContributionHelper>();
            var executive = new Executive(PERSONAL_PENSION_PERCENT, _mockCompanyPensionContributionHelper.Object,
            _mockBenefitCalculator.Object);

            //Act
            executive.GetTotalCompanyContributions();

            //Assert
            _mockBenefitCalculator.Verify(m =>
                m.GetTotalCompanyContributions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>()));
        }

        [Test]
        public void GetTotalPension_WhenCalled_ShouldUseTheBenefitCalculatorMethod()
        {
            //Arrange
            _mockBenefitCalculator = new Mock<IBenefitCalculator>();
            _mockCompanyPensionContributionHelper = new Mock<ICompanyPensionContributionHelper>();
            var executive = new Executive(PERSONAL_PENSION_PERCENT, _mockCompanyPensionContributionHelper.Object,
                _mockBenefitCalculator.Object);

            //Act
            executive.GetTotalPension();

            //Assert
            _mockBenefitCalculator.Verify(m =>
                m.GetTotalPension(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void EmployeeType_WhenCalled_ShouldReturnTheEmployeeType()
        {
            //Arrange
            _mockBenefitCalculator = new Mock<IBenefitCalculator>();
            _mockCompanyPensionContributionHelper = new Mock<ICompanyPensionContributionHelper>();
            var executive = new Executive(PERSONAL_PENSION_PERCENT, _mockCompanyPensionContributionHelper.Object,
                _mockBenefitCalculator.Object);
            var expected = "Executive";

            //Act
            var result = executive.EmployeeType();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
