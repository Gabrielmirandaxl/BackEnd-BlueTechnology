using AutoMapper;
using crud.Dtos;
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

    private readonly IMapper mapper;

    public UserController(IUserServices services, IMapper mapper)
    {
      this.services = services;
      this.mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserDetailsDto userDetailsDto)
    {

      userDetailsDto.CreateRegistration = DateTime.Now;
      userDetailsDto.UpdateRegistration = DateTime.Now;

      var userCreate = this.mapper.Map<UserModel>(userDetailsDto);

      this.services.CreateUser(userCreate);

      return await this.services.SaveChangesAsync()
      ? Ok(userCreate)
      : BadRequest("Erro ao criar usuário");

    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

      var users = await this.services.GetAllUser();

      return Ok(users.Select(user => this.mapper.Map<UserDto>(user)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
      var user = await this.services.GetOneUser(id);


      var userDetails = this.mapper.Map<UserDetailsDto>(user);

      return user != null
      ? Ok(userDetails)
      : NotFound("Usuário não encontrado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

      var user = await this.services.GetOneUser(id);

      if (user == null) return NotFound("Usuário não encontrado");

      this.services.DeleteUser(user);

      return await this.services.SaveChangesAsync()
      ? Ok("Usuário removido com sucesso")
      : BadRequest("Erro ao remover o usuário");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UserDetailsDto userDetailsDto)
    {

      var user = await this.services.GetOneUser(id);

      if (user == null) return NotFound("Usuário não encontrado");

      var userUpdate = this.mapper.Map<UserModel>(userDetailsDto);

      user.Name = userUpdate.Name;
      user.Email = userUpdate.Email;
      user.Telefone = userUpdate.Telefone;
      user.Cpf = userUpdate.Cpf;
      user.UpdateRegistration = DateTime.Now;

      this.services.UpdateUser(user);

      return await this.services.SaveChangesAsync()
      ? Ok(user)
      : BadRequest("Erro ao atualizar o usuário");

    }

    [HttpGet("/search")]
    public async Task<IActionResult> Get([FromQuery] string email)
    {

      var user = await this.services.SearchOneUser(email);

      var userDetails = this.mapper.Map<UserDetailsDto>(user);

      return user == null
      ? NotFound("Usuário não encontrado")
      : Ok(userDetails);

    }


  }
}