using System;
using Payroll.Helpers;

namespace Payroll.Employees
{
    public class Executive : Employee
    {
        private const string ROLE = "Executive";
        private const int BASIC_SALARY = 30000;
        private const int BONUS_PERCENT = 5;
        private const int MAX_COMPANY_CONTRIBUTION_PERCENT = 5;
        private const bool HEALTH_INSURANCE = false;
        private readonly ICompanyPensionContributionHelper _companyPensionContributionHelper;

        public Executive(int personalPensionContributionPercent, ICompanyPensionContributionHelper companyPensionContributionHelper, IBenefitCalculator benefitCalculator)
            : base(ROLE, BASIC_SALARY, BONUS_PERCENT, personalPensionContributionPercent,
            HEALTH_INSURANCE, benefitCalculator)
        {
            _companyPensionContributionHelper = companyPensionContributionHelper;

            base.CompanyPensionContributionPercent = _companyPensionContributionHelper.CalculateCompanyPensionContribution(MAX_COMPANY_CONTRIBUTION_PERCENT,
                personalPensionContributionPercent);
        }

        public Executive(int personalPensionContributionPercent) : this(personalPensionContributionPercent,
            new CompanyPensionContributionHelper(), new BenefitCalculator())
        {
            if (personalPensionContributionPercent < 0 || personalPensionContributionPercent > 5)
                throw new ArgumentOutOfRangeException();
        }
    }
}
