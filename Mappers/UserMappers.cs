using AutoMapper;
using crud.Dtos;
using crud.Model;

namespace crud.Mappers
{
  public class UserMappers : Profile
  {
    public UserMappers()
    {
      CreateMap<UserModel, UserDetailsDto>();
    }
  }
}