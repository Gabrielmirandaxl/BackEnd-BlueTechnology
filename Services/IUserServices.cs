
using crud.Model;

namespace crud.Services
{
  public interface IUserServices
  {
    Task<IEnumerable<UserModel>> GetAllUser();

    Task<UserModel> GetOneUser(int id);

    void CreateUser(UserModel userModel);

    void UpdateUser(UserModel userModel);

    void DeleteUser(UserModel userModel);
  }
}