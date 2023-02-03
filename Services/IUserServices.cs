
using crud.Dtos;
using crud.Model;

namespace crud.Services
{
  public interface IUserServices
  {
    Task<IEnumerable<UserDto>> GetAllUser();

    Task<UserModel> GetOneUser(int id);

    void CreateUser(UserModel userModel);

    void UpdateUser(UserModel userModel);

    void DeleteUser(UserModel userModel);

    Task<bool> SaveChangesAsync();
  }
}