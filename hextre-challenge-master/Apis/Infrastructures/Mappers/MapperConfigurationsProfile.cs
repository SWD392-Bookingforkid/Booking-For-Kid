using AutoMapper;
using Domain.Entities;
using Application.ViewModels.UserViewModels;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            CreateMap<User, UserLoginDTO>().ReverseMap();
        }
    }
}
