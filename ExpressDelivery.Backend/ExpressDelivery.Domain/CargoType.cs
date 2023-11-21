
namespace ExpressDelivery.Domain
{
    public class CargoType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActual { get; set; }
        public DateTime Ts { get; set; }
    }
}
