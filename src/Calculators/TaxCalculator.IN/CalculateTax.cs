using TaxCalculator.Contract;
using TaxCalculator.Model;

namespace TaxCalculator.IN
{
    public class CalculateTax : ITaxCalculator
    {
        public Order CalulateTax(Order order)
        {
            foreach(var oi in order.OrderItems)
            {
                oi.Amount = oi.Quantity * oi.Price;
                oi.Tax = oi.Amount * 15/100; //10 percent tax
                oi.Total = oi.Amount + oi.Tax;
            }

            order.TotalTax = order.OrderItems.Sum(t => t.Tax);
            order.TotalAmount = order.OrderItems.Sum(t => t.Total);

            return order;
        }
    }
}