namespace Payroll.Helpers
{
    public interface IBenefitCalculator
    {
        int GetTotalCompanyContributions(int companyPensionContributionPercent, int bonus, int basicSalary,
            bool healthInsurance);

        int GetTotalPension(int companyPensionContribution, int personalPensionContribution, int basicSalary);

        int CalculateBonus(int basicSalary, int bonus);
        int CalculatePension(int basicSalary, int pensionContribution);
    }
}