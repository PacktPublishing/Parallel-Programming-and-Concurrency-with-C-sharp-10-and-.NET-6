namespace ConcurrentOrderQueue
{
    public class Order
    {
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public int ItemQty { get; set; }
        public int CustomerId { get; set; }
        public decimal OrderTotal { get; set; }
    }
}