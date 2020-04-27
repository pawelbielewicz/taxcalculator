using PolishVATLib;

namespace PolishVATWebServices.Repositories
{
    public class VATRepository
    {
        private IVATCalculation _vatCalculation;

        public VATRepository(IVATCalculation vatCalculation)
        {
            _vatCalculation = vatCalculation;
        }

        public double Gross(double price, int quantity)
        {
            return _vatCalculation.CalculateGrossAmount(price) * quantity;
        }

        ///Calculate net price
        public double Net(double price, int quantity)
        {
            return _vatCalculation.CalculateNetAmount(price) * quantity;
        }

        ///Calculate tax
        public double Tax(double price, int quantity)
        {
            return _vatCalculation.CalculateTax(price) * quantity;
        }
    }
}