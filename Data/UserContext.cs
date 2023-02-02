using crud.Model;
using Microsoft.EntityFrameworkCore;


namespace crud.Data
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }

  }
}