using System.Security.Cryptography.X509Certificates;
using crud.Data;
using crud.Dtos;
using crud.Libs;
using crud.Model;
using Microsoft.EntityFrameworkCore;

namespace crud.Services
{
  public class UserServices : IUserServices
  {

    private readonly UserContext context;

    public UserServices(UserContext context)
    {
      this.context = context;
    }

    public void CreateUser(UserModel userModel)
    {

      ValidationUser.Validation(userModel);

      this.context.Add(userModel);
    }

    public async Task<IEnumerable<UserDto>> GetAllUser()
    {
      return await this.context.Users
      .Select(x => new UserDto { Id = x.Id, Name = x.Name, Email = x.Email, Telefone = x.Telefone })
      .ToListAsync();
    }

    public async Task<UserModel> GetOneUser(int id)
    {
      return await this.context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public void UpdateUser(UserModel userModel)
    {

      ValidationUser.Validation(userModel);

      this.context.Update(userModel);
    }

    public void DeleteUser(UserModel userModel)
    {
      this.context.Remove(userModel);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await this.context.SaveChangesAsync() > 0;
    }


  }
}