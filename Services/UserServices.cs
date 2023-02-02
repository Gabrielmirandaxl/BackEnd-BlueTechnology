using crud.Data;
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
      this.context.Add(userModel);
    }

    public void DeleteUser(UserModel userModel)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserModel>> GetAllUser()
    {
      return await this.context.Users.ToListAsync();
    }

    public async Task<UserModel> GetOneUser(int id)
    {
      return await this.context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public void UpdateUser(UserModel userModel)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await this.context.SaveChangesAsync() > 0;
    }


  }
}