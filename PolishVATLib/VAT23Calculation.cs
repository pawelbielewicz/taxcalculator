namespace PolishVATLib
{
    public class VAT23Calculation : IVATCalculation
    {
        public string Name => "23%";

        public VAT23Calculation()
        {

        }

        public double CalculateGrossAmount(double netPrice)
        {
            return netPrice * 1.23;
        }

        public double CalculateNetAmount(double grossPrice)
        {
            return grossPrice / 1.23;
        }

        public double CalculateTax(double netPrice)
        {
            return netPrice * 0.23;
        }
    }
}
