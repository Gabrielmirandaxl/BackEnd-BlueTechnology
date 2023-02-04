using AutoMapper;
using crud.Dtos;
using crud.Model;

namespace crud.Mappers
{
  public class UserMappers : Profile
  {
    public UserMappers()
    {
      CreateMap<UserModel, UserDto>();
      CreateMap<UserModel, UserDetailsDto>();
      CreateMap<UserDetailsDto, UserModel>();
    }
  }
}