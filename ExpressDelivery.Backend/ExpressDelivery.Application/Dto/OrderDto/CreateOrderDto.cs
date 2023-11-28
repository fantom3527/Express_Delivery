using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.OrderDto
{
    public record class CreateOrderDto : IMapWith<Order>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ReceiptAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public string Description { get; set; }
        public DateTime ReceiptTime { get; set; }
        public DateTime DeliveryTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, Order>()
                   .ForPath(order => order.UserId,
                       opt => opt.MapFrom(createOrderDto => createOrderDto.UserId))
                   .ForPath(order => order.Name,
                       opt => opt.MapFrom(createOrderDto => createOrderDto.Name))
                   .ForPath(order => order.ReceiptAddress,
                       opt => opt.MapFrom(createOrderDto => createOrderDto.ReceiptAddress))
                   .ForPath(order => order.DeliveryAddress,
                       opt => opt.MapFrom(createOrderDto => createOrderDto.DeliveryAddress))
                   .ForPath(order => order.Description,
                       opt => opt.MapFrom(createOrderDto => createOrderDto.Description))
                   .ForPath(order => order.ReceiptTime,
                       opt => opt.MapFrom(createOrderDto => createOrderDto.ReceiptTime))
                   .ForPath(order => order.DeliveryTime,
                       opt => opt.MapFrom(createOrderDto => createOrderDto.DeliveryTime));
        }
    }
}
