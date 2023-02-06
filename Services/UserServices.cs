using crud.Libs;
using crud.Model;
using crud.Repository;

namespace crud.Services
{
  public class UserServices : IUserServices
  {

    private readonly IRepositoryUser repository;

    public UserServices(IRepositoryUser repository)
    {
      this.repository = repository;
    }

    public void CreateUser(UserModel userModel)
    {

      ValidationUser.Validation(userModel);

      this.repository.CreateUser(userModel);
    }

    public async Task<IEnumerable<UserModel>> GetAllUser()
    {
      return await this.repository.GetAllUser();
    }

    public Task<UserModel> GetOneUser(int id)
    {
      throw new NotImplementedException();

    }

    public Task<UserModel> SearchOneUser(string email)
    {
      throw new NotImplementedException();

    }

    public void UpdateUser(UserModel userModel)
    {

      ValidationUser.Validation(userModel);

      this.repository.UpdateUser(userModel);
    }

    public void DeleteUser(UserModel userModel)
    {
      this.repository.DeleteUser(userModel);
    }


  }
}