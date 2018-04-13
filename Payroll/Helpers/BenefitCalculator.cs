namespace Payroll.Helpers
{
    class BenefitCalculator : IBenefitCalculator
    {
        public int GetTotalCompanyContributions(int companyPensionContributionPercent, int bonusPercent, int basicSalary,
            bool healthInsurance)
        {
            var bonusValue = CalculateBonus(basicSalary, bonusPercent);
            var companyPensionValue = CalculatePension(basicSalary, companyPensionContributionPercent);
            var healthInsuranceValue = healthInsurance ? 1000 : 0;
            return companyPensionValue + bonusValue + basicSalary + healthInsuranceValue;
        }

        public int GetTotalPension(int companyPensionContributionPercent, int personalPensionContributionPercent, int basicSalary)
        {
            return CalculatePension(basicSalary, companyPensionContributionPercent) + CalculatePension(basicSalary, personalPensionContributionPercent);
        }

        public int CalculateBonus(int basicSalary, int bonusPercent)
        {
            return basicSalary * bonusPercent / 100;
        }

        public int CalculatePension(int basicSalary, int pensionContributionPercent)
        {
            return basicSalary * pensionContributionPercent / 100;
        }
    }
}
