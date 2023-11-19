namespace ExpressDelivery.Domain
{
    public class Cargo
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int CargoTypeId { get; set; } //TODO Типы вида посылка, письмо и тд. Наверное сделать Enum
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Ts { get; set; }
        public CargoType CargoType { get; set; }
        public Order Order { get; set; }
    }
}
