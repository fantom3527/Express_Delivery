using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.OrderDto
{
    public record class UpdateOrderDto : IMapWith<Order>
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
            profile.CreateMap<UpdateOrderDto, Order>()
                   .ForPath(order => order.Id,
                       opt => opt.MapFrom(updateOrderDto => updateOrderDto.Id))
                   .ForPath(order => order.OrderStatusId,
                       opt => opt.MapFrom(updateOrderDto => updateOrderDto.OrderStatusId))
                   .ForPath(order => order.Name,
                       opt => opt.MapFrom(updateOrderDto => updateOrderDto.Name))
                   .ForPath(order => order.ReceiptAddress,
                       opt => opt.MapFrom(updateOrderDto => updateOrderDto.ReceiptAddress))
                   .ForPath(order => order.DeliveryAddress,
                       opt => opt.MapFrom(updateOrderDto => updateOrderDto.DeliveryAddress))
                   .ForPath(order => order.Description,
                       opt => opt.MapFrom(updateOrderDto => updateOrderDto.Description))
                   .ForPath(order => order.ReceiptTime,
                       opt => opt.MapFrom(updateOrderDto => updateOrderDto.ReceiptTime))
                   .ForPath(order => order.DeliveryTime,
                       opt => opt.MapFrom(updateOrderDto => updateOrderDto.DeliveryTime));
        }
    }
}
