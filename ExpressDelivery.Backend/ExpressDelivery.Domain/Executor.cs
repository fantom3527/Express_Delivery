namespace ExpressDelivery.Domain
{
    public class Executor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExecutorStatusId { get; set; }
        public DateTime Ts { get; set; }
        public ExecutorStatus ExecutorStatus { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
