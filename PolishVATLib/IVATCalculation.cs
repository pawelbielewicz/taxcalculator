namespace PolishVATLib
{
    public interface IVATCalculation
    {
        string Name { get; }
        double CalculateTax(double netPrice);
        double CalculateGrossAmount(double netPrice);
        double CalculateNetAmount(double grossPrice);
    }
}
