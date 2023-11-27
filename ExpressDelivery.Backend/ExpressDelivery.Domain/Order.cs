namespace ExpressDelivery.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public int OrderStatusId { get; set; }
        public Guid? ExecutorId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ReceiptAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public string Description { get; set; }
        public DateTime ReceiptTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public DateTime Ts { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Executor Executor { get; set; }
        public User User { get; set; }
        public IEnumerable<Cargo> Cargos { get; set; }
        public IEnumerable<OrderHistory> OrderHistories { get; set; }
    }
}
