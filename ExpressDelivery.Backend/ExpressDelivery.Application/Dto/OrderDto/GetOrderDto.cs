using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.OrderDto
{
    public record class GetOrderDto : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public int OrderStatusId { get; set; }
        public string Name { get; set; }
        public string ReceiptAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public string Description { get; set; }
        public DateTime ReceiptTime { get; set; }
        public DateTime DeliveryTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, GetOrderDto>()
                   .ForPath(getOrderDto => getOrderDto.Id,
                       opt => opt.MapFrom(order => order.Id))
                   .ForPath(getOrderDto => getOrderDto.OrderStatusId,
                       opt => opt.MapFrom(order => order.OrderStatusId))
                   .ForPath(getOrderDto => getOrderDto.Name,
                       opt => opt.MapFrom(order => order.Name))
                   .ForPath(getOrderDto => getOrderDto.ReceiptAddress,
                       opt => opt.MapFrom(order => order.ReceiptAddress))
                   .ForPath(getOrderDto => getOrderDto.DeliveryAddress,
                       opt => opt.MapFrom(order => order.DeliveryAddress))
                   .ForPath(getOrderDto => getOrderDto.Description,
                       opt => opt.MapFrom(order => order.Description))
                   .ForPath(getOrderDto => getOrderDto.ReceiptTime,
                       opt => opt.MapFrom(order => order.ReceiptTime))
                   .ForPath(getOrderDto => getOrderDto.DeliveryTime,
                       opt => opt.MapFrom(order => order.DeliveryTime));
        }
    }
}
