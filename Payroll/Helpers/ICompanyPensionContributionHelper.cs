namespace Payroll.Helpers
{
    public interface ICompanyPensionContributionHelper
    {
        int CalculateCompanyPensionContribution(int maxCompanyPensionContribution, int personalPensionContribution);
    }
}