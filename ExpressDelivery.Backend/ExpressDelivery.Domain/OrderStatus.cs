namespace ExpressDelivery.Domain
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Actual { get; set; }
        public DateTime Ts { get; set; }
        public List<Order> Orders { get; set; }
    }
}
