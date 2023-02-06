
using crud.Data;
using crud.Model;
using Microsoft.EntityFrameworkCore;

namespace crud.Repository
{
  public class RepositoryUser : IRepositoryUser
  {

    private readonly UserContext context;

    public RepositoryUser(UserContext context)
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

    public async Task<bool> SaveChangesAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<UserModel> SearchOneUser(string email)
    {
      return await this.context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
    }

    public void UpdateUser(UserModel userModel)
    {
      this.context.Update(userModel);
    }

    public async Task<bool> SavesChangesAsync()
    {
      return await this.context.SaveChangesAsync() > 0;
    }
  }
}