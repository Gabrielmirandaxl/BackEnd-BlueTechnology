using crud.Data;
using crud.Libs;
using crud.Model;
using crud.Repository;

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

      userModel.CreateRegistration = DateTime.Now;


      this.repository.CreateUser(userModel);
    }

    public async Task<IEnumerable<UserModel>> GetAllUser()
    {
      return await this.repository.GetAllUser();
    }

    public async Task<UserModel> GetOneUser(int id)
    {

      var user = await this.repository.GetOneUser(id);

      if (user == null) throw new ArgumentException("Usuário não encontrado");

      return await this.repository.GetOneUser(id);
    }

    public async Task<UserModel> SearchOneUser(string email)
    {

      var user = await this.repository.SearchOneUser(email);

      if (user == null) throw new ArgumentException("Usuário não encontrado");

      return await this.repository.SearchOneUser(email);
    }

    public async void UpdateUserAsync(int id, UserModel userUpdate)
    {

      ValidationUser.Validation(userUpdate);

      var user = await this.repository.GetOneUser(id);

      user.Name = userUpdate.Name;
      user.Email = userUpdate.Email;
      user.Telefone = userUpdate.Telefone;
      user.Cpf = userUpdate.Cpf;
      user.UpdateRegistration = DateTime.Now;

      this.repository.UpdateUser(user);
    }

    public void DeleteUser(int id, UserModel userModel)
    {

      var user = this.repository.GetOneUser(id);

      if (user == null) throw new ArgumentException("Usuário não encontrado");

      this.repository.DeleteUser(userModel);
    }

  }
}