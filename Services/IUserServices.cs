using crud.Model;

namespace crud.Services
{
  public interface IUserServices
  {
    Task<IEnumerable<UserModel>> GetAllUser();

    Task<UserModel> GetOneUser(int id);

    Task<UserModel> SearchOneUser(string email);

    void CreateUser(UserModel userModel);

    void UpdateUser(int id, UserModel userModel);

    void DeleteUser(UserModel userModel);



  }
}