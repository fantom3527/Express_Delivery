﻿using AutoMapper;
using ExpressDelivery.Application.Dto.UserDto;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services.Interfaces;

namespace ExpressDelivery.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
            => (_userRepository, _mapper) = (userRepository, mapper);

        public async Task<IEnumerable<GetUserDto>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GetUserDto>>(await _userRepository.GetAll(cancellationToken));
        }

        public async Task<GetUserDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetUserDto>(await _userRepository.Get(id, cancellationToken));
        }
    }
}
