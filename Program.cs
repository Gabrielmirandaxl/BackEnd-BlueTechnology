using crud.Data;
using crud.Middlewares;
using crud.Repository;
using crud.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string MysqlConnection = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<UserContext>(options =>
{

  options.UseMySql(MysqlConnection,
   ServerVersion.AutoDetect(MysqlConnection));

});

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalErrorMiddleware));

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
