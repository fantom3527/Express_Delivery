using AutoMapper;
using ExpressDelivery.Application.Common.Mapping;
using ExpressDelivery.Domain;

namespace ExpressDelivery.Application.Dto.UserDto
{
    public record class GetUserDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetUserDto>()
                   .ForPath(getUserDto => getUserDto.Id,
                       opt => opt.MapFrom(User => User.Id))
                   .ForPath(getUserDto => getUserDto.Name,
                       opt => opt.MapFrom(User => User.Name))
                   .ForPath(getUserDto => getUserDto.Description,
                       opt => opt.MapFrom(User => User.Description));
        }
    }
}
