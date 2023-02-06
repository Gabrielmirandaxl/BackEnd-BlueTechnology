using crud.Model;

namespace crud.Services
{
  public interface IUserServices
  {
    Task<IEnumerable<UserModel>> GetAllUser();
    Task<UserModel> GetOneUser(int id);
    Task<UserModel> SearchOneUser(string email);
    void CreateUser(UserModel userModel);
    void UpdateUserAsync(int id, UserModel userModel);
    void DeleteUser(int id, UserModel userModel);
  }
}