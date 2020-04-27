namespace PolishVATLib
{
    public class VAT8Calculation : IVATCalculation
    {
        public string Name => "8%";
        public VAT8Calculation()
        {

        }
        
        public double CalculateGrossAmount(double netPrice)
        {
            return netPrice * 1.08;
        }

        public double CalculateNetAmount(double grossPrice)
        {
            return grossPrice / 1.08;
        }

        public double CalculateTax(double netPrice)
        {
            return netPrice * 0.08;
        }
    }
}
