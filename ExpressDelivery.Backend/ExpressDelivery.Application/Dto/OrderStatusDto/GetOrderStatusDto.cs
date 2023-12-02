using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.OrderStatusDto
{
    public class GetOrderStatusDto : IMapWith<OrderStatus>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActual { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderStatus, GetOrderStatusDto>()
                   .ForPath(getOrderStatusDto => getOrderStatusDto.Id,
                       opt => opt.MapFrom(orderStatus => orderStatus.Id))
                   .ForPath(getOrderStatusDto => getOrderStatusDto.Name,
                       opt => opt.MapFrom(orderStatus => orderStatus.Name))
                   .ForPath(getOrderStatusDto => getOrderStatusDto.Code,
                       opt => opt.MapFrom(orderStatus => orderStatus.Code))
                   .ForPath(getOrderStatusDto => getOrderStatusDto.IsActual,
                       opt => opt.MapFrom(orderStatus => orderStatus.IsActual));
        }
    }
}
