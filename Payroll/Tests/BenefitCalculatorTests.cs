using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Payroll.Helpers;

namespace Payroll.Tests
{

    [TestFixture]
    class BenefitCalculatorTests
    {
        private const int BASIC_SALARY = 50000;
        private const int PERSONAL_PENSION_CONTRIBUTION_PERCENT = 5;
        private const int COMPANY_PENSION_CONTRIBUTION_PERCENT = 2;
        private const int BONUS_PERCENT = 10;
        private readonly BenefitCalculator _benefitCalculator = new BenefitCalculator();

        [Test]
        public void CalculatePension_WhenCalledWithSalaryAndPensionRate_ShouldCalculateThePensionValue()
        {
            //Arrange
            var expected = 2500;

            //Act
            var result = _benefitCalculator.CalculatePension(BASIC_SALARY, PERSONAL_PENSION_CONTRIBUTION_PERCENT);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateBonus_WhenCalledWithSalaryAndBonusRate_ShouldCalculateTheBonusValue()
        {
            //Arrange
            var expected = 5000;

            //Act
            var result = _benefitCalculator.CalculateBonus(BASIC_SALARY, BONUS_PERCENT);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void
            GetTotalPension_WhenCalledWithSalaryAndPersonalPensionRateAndCompanyPensionRate_ShouldCalculateTheTotalPensionValue()
        {
            //Arrange
            var expected = 3500;

            //Act
            var result = _benefitCalculator.GetTotalPension(COMPANY_PENSION_CONTRIBUTION_PERCENT,
                PERSONAL_PENSION_CONTRIBUTION_PERCENT, BASIC_SALARY);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetTotalCompanyContributions_WhenCalledCompanyPensionRateAndBonusRateAndSalaryAndNoHealthInsurance_ShouldCalculateTheTotalCompanyContribution()
        {
            //Arrange
            var expected = 56000;
            var healthInsurance = false;

            //Act
            var result = _benefitCalculator.GetTotalCompanyContributions(COMPANY_PENSION_CONTRIBUTION_PERCENT,
                BONUS_PERCENT, BASIC_SALARY, healthInsurance);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetTotalCompanyContributions_WhenCalledCompanyPensionRateAndBonusRateAndSalaryAndWithHealthInsurance_ShouldCalculateTheTotalCompanyContribution()
        {
            //Arrange
            var expected = 57000;
            var healthInsurance = true;

            //Act
            var result = _benefitCalculator.GetTotalCompanyContributions(COMPANY_PENSION_CONTRIBUTION_PERCENT,
                BONUS_PERCENT, BASIC_SALARY, healthInsurance);

            //Assert
            Assert.AreEqual(expected, result);
        }

    }
}
