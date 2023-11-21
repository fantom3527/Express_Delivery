namespace ExpressDelivery.Domain
{
    public class OrderHistory
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int OrderHistoryMethodId { get; set; }
        public string Description { get; set; }
        public DateTime Ts { get; set; }
        //TODO Реализовать, если успею историю по заказам. А пока в описание буду писать что произошло с заказом
        public Order Order { get; set; }
        public OrderHistoryMethod OrderHistoryMethod { get; set; }
    }
}
