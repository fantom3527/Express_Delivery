using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.OrderHistoryDto
{
    public class GetOrderHistoryDto : IMapWith<OrderHistory>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int OrderHistoryMethodId { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderHistory, GetOrderHistoryDto>()
                   .ForPath(getOrderHistoryDto => getOrderHistoryDto.Id,
                       opt => opt.MapFrom(orderHistory => orderHistory.Id))
                   .ForPath(getOrderHistoryDto => getOrderHistoryDto.OrderId,
                       opt => opt.MapFrom(orderHistory => orderHistory.OrderId))
                   .ForPath(getOrderHistoryDto => getOrderHistoryDto.OrderHistoryMethodId,
                       opt => opt.MapFrom(orderHistory => orderHistory.OrderHistoryMethodId))
                   .ForPath(getOrderHistoryDto => getOrderHistoryDto.Description,
                       opt => opt.MapFrom(orderHistory => orderHistory.Description));
        }
    }
}
