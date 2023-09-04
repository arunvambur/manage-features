using TaxCalculator.Model;

namespace TaxCalculator.Contract
{
    public interface ITaxCalculator
    {
        Order CalulateTax(Order order);
    }
}