using crud.Data;
using crud.Libs;
using crud.Model;
using crud.Repository;
using Microsoft.EntityFrameworkCore;

namespace crud.Services
{
  public class UserServices : IUserServices
  {

    private readonly IRepositoryUser repository;

    private readonly UserContext context;

    public UserServices(IRepositoryUser repository, UserContext context)
    {
      this.repository = repository;
      this.context = context;
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

    public async Task<UserModel> GetOneUser(int id)
    {

      var user = await this.context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

      if (user == null) throw new ArgumentException("Usuário não encontrado");

      return await this.repository.GetOneUser(id);

    }

    public async Task<UserModel> SearchOneUser(string email)
    {

      var user = await this.context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

      if (user == null) throw new ArgumentException("Usuário não encontrado");

      return await this.repository.SearchOneUser(email);

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