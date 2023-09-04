using TaxCalculator.Contract;
using TaxCalculator.Model;

namespace TaxCalculator.US
{
    public class CalculateTax : ITaxCalculator
    {
        public Order CalulateTax(Order order)
        {
            foreach (var oi in order.OrderItems)
            {
                oi.Amount = oi.Quantity * oi.Price;
                oi.Tax = oi.Amount * 8 / 100; //8 percent tax
                oi.Total = oi.Amount + oi.Tax;
            }

            order.TotalTax = order.OrderItems.Sum(t => t.Tax);
            order.TotalAmount = order.OrderItems.Sum(t => t.Total);

            return order;
        }
    }
}