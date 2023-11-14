namespace ExpressDelivery.Domain
{
    public class ExecutorStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Actual { get; set; }
        public DateTime Ts { get; set; }
        public List<Executor> Executors { get; set; }
    }
}
