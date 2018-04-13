namespace Payroll.Helpers
{
    class CompanyPensionContributionHelper : ICompanyPensionContributionHelper
    {
        public int CalculateCompanyPensionContribution(int maxCompanyPensionContribution, int personalPensionContribution)
        {
            return personalPensionContribution > maxCompanyPensionContribution ? maxCompanyPensionContribution : personalPensionContribution;
        }
    }
}
