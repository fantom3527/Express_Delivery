using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.OrderHistoryMethodDto
{
    public class GetOrderHistoryMethodDto : IMapWith<OrderHistoryMethod>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActual { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderHistoryMethod, GetOrderHistoryMethodDto>()
                   .ForPath(getOrderHistoryMethodDto => getOrderHistoryMethodDto.Id,
                       opt => opt.MapFrom(orderHistoryMethod => orderHistoryMethod.Id))
                   .ForPath(getOrderHistoryMethodDto => getOrderHistoryMethodDto.Name,
                       opt => opt.MapFrom(orderHistoryMethod => orderHistoryMethod.Name))
                   .ForPath(getOrderHistoryMethodDto => getOrderHistoryMethodDto.Code,
                       opt => opt.MapFrom(orderHistoryMethod => orderHistoryMethod.Code))
                   .ForPath(getOrderHistoryMethodDto => getOrderHistoryMethodDto.IsActual,
                       opt => opt.MapFrom(orderHistoryMethod => orderHistoryMethod.IsActual));
        }
    }
}
