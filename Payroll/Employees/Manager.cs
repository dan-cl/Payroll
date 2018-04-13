using System;
using Payroll.Helpers;

namespace Payroll.Employees
{
    public class Manager : Employee
    {
        private const string ROLE = "Manager";
        private const int BASIC_SALARY = 50000;
        private const int BONUS_PERCENT = 10;
        private const int COMPANY_CONTRIBUTION_PERCENT = 5;
        private const bool HEALTH_INSURANCE = true;

        public Manager(int personalPensionContributionPercent, IBenefitCalculator benefitCalculator)
            : base(ROLE, BASIC_SALARY, BONUS_PERCENT, personalPensionContributionPercent,
                HEALTH_INSURANCE, benefitCalculator)
        {
            base.CompanyPensionContributionPercent = COMPANY_CONTRIBUTION_PERCENT;
        }

        public Manager(int personalPensionContributionPercent) : this(personalPensionContributionPercent,
            new BenefitCalculator())
        {
            if (personalPensionContributionPercent < 0 || personalPensionContributionPercent > 5)
                throw new ArgumentOutOfRangeException();
        }
    }
}
