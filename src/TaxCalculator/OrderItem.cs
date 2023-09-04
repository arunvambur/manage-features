namespace TaxCalculator
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public OrderItem[] OrderItems { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalAmount { get; set; }

    }

    public class OrderItem
    {
        public int ItemId { get; set; }
        public string ItemDetail { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        
    }
}