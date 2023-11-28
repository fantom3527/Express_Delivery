namespace ExpressDelivery.Domain
{
    public class OrderHistory
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int OrderHistoryMethodId { get; set; }
        public string Description { get; set; }
        public DateTime Ts { get; set; }
        public Order Order { get; set; }
        public OrderHistoryMethod OrderHistoryMethod { get; set; }
    }
}
