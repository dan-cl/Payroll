using System;
using Payroll.Helpers;

namespace Payroll.Employees
{
    public class Director : Employee
    {
        private const string ROLE = "Director";
        private const int BASIC_SALARY = 75000;
        private const int BONUS_PERCENT = 20;
        private const int COMPANY_CONTRIBUTION_PERCENT = 10;
        private const bool HEALTH_INSURANCE = true;

        public Director(int personalPensionContributionPercent, IBenefitCalculator benefitCalculator)
            : base(ROLE, BASIC_SALARY, BONUS_PERCENT, personalPensionContributionPercent,
                HEALTH_INSURANCE, benefitCalculator)
        {
            base.CompanyPensionContributionPercent = COMPANY_CONTRIBUTION_PERCENT;
        }

        public Director(int personalPensionContributionPercent) : this(personalPensionContributionPercent,
            new BenefitCalculator())
        {
            if (personalPensionContributionPercent < 0 || personalPensionContributionPercent > 5)
                throw new ArgumentOutOfRangeException();
        }
    }
}
