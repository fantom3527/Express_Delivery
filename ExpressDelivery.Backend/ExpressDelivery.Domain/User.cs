namespace ExpressDelivery.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Ts { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
