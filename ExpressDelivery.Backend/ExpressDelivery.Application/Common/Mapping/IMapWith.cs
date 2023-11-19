using AutoMapper;

namespace ExpressDelivery.Application.Common.Mapping
{
    public interface IMapWith<T>
    {
        /// <summary>
        /// Создает конфигурацию из исходного типа Т и к назнначению.
        /// </summary>
        /// <param name="profile"></param>
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
