using Payroll.Helpers;

namespace Payroll.Employees
{
    public abstract class Employee
    {
        private readonly string _role;
        private readonly int _basicSalary;
        private readonly int _bonusPercent;
        private readonly int _personalPensionContibutionPercent;
        public int CompanyPensionContributionPercent;
        private readonly bool _healthInsurance;
        private readonly IBenefitCalculator _benefitCalculator;


        protected Employee(string role, int basicSalary, int bonusPercent, int personalPensionContibutionPercent,
            bool healthInsurance, IBenefitCalculator benefitCalculator)
        {
            _role = role;
            _basicSalary = basicSalary;
            _bonusPercent = bonusPercent;
            _personalPensionContibutionPercent = personalPensionContibutionPercent;
            _healthInsurance = healthInsurance;
            _benefitCalculator = benefitCalculator;
        }

        public int GetTotalCompanyContributions()
        {
            return _benefitCalculator.GetTotalCompanyContributions(CompanyPensionContributionPercent, _bonusPercent, _basicSalary,
                _healthInsurance);
        }

        public int GetTotalPension()
        {
            return _benefitCalculator.GetTotalPension(CompanyPensionContributionPercent, _personalPensionContibutionPercent, _basicSalary);
        }

        public string EmployeeType()
        {
            return this._role;
        }
    }
}