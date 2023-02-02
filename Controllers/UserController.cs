
using crud.Model;
using crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{

  [ApiController]
  [Route("api/[controller]")]

  public class UserController : ControllerBase
  {

    private readonly IUserServices services;

    public UserController(IUserServices services)
    {
      this.services = services;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserModel userModel)
    {

      userModel.CreateRegistration = DateTime.Now;
      userModel.UpdateRegistration = DateTime.Now;

      this.services.CreateUser(userModel);

      return await this.services.SaveChangesAsync()
      ? Ok("Usuário criado")
      : BadRequest("Erro ao criar usuário");

    }



  }
}