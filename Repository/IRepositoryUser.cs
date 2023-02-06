using crud.Model;

namespace crud.Repository
{
  public interface IRepositoryUser
  {
    Task<IEnumerable<UserModel>> GetAllUser();
    Task<UserModel> GetOneUser(int id);
    Task<UserModel> SearchOneUser(string email);
    void CreateUser(UserModel userModel);
    void UpdateUser(UserModel userModel);
    void DeleteUser(UserModel userModel);
    Task<bool> SavesChangesAsync();
  }
}