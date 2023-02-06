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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      var user = modelBuilder.Entity<UserModel>();

      user.ToTable("tb_users");
      user.HasKey(x => x.Id);
      user.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
      user.Property(x => x.Name).HasColumnName("name").IsRequired();
      user.Property(x => x.Telefone).HasColumnName("telefone").IsRequired();
      user.Property(x => x.Email).HasColumnName("email").IsRequired();
      user.Property(x => x.Cpf).HasColumnName("cpf").IsRequired();
      user.Property(x => x.CreateRegistration).HasColumnName("createRegistration");
      user.Property(x => x.UpdateRegistration).HasColumnName("updateRegistration");
    }
  }
}