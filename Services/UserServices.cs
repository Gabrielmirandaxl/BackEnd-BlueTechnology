using crud.Model;

namespace crud.Services
{
  public class UserServices : IUserServices
  {
    public void CreateUser(UserModel userModel)
    {
      throw new NotImplementedException();
    }

    public void DeleteUser(UserModel userModel)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<UserModel>> GetAllUser()
    {
      throw new NotImplementedException();
    }

    public Task<UserModel> GetOneUser(int id)
    {
      throw new NotImplementedException();
    }

    public void UpdateUser(UserModel userModel)
    {
      throw new NotImplementedException();
    }
  }
}