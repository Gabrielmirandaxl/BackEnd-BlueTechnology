using AutoMapper;
using crud.Dtos;
using crud.Model;
using crud.Repository;
using crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {

    private readonly IUserServices services;
    private readonly IRepositoryUser repository;

    private readonly IMapper mapper;

    public UserController(IUserServices services, IRepositoryUser repository, IMapper mapper)
    {
      this.services = services;
      this.repository = repository;
      this.mapper = mapper;

    }

    [HttpPost]
    public async Task<IActionResult> Post(UserDetailsDto userDetailsDto)
    {

      userDetailsDto.CreateRegistration = DateTime.Now;

      var userCreate = this.mapper.Map<UserModel>(userDetailsDto);

      this.services.CreateUser(userCreate);

      return await this.repository.SavesChangesAsync()
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

      this.services.DeleteUser(id, user);

      return await this.repository.SavesChangesAsync()
      ? Ok("Usuário removido com sucesso")
      : BadRequest("Erro ao remover o usuário");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UserDetailsDto userDetailsDto)
    {

      var user = await this.services.GetOneUser(id);

      var userUpdate = this.mapper.Map<UserModel>(userDetailsDto);

      this.services.UpdateUser(id, userUpdate);

      return await this.repository.SavesChangesAsync()
      ? Ok(user)
      : BadRequest("Erro ao atualizar o usuário");
    }

    [HttpGet("/search")]
    public async Task<IActionResult> Get([FromQuery] string email)
    {

      var user = await this.services.SearchOneUser(email);

      var userDetails = this.mapper.Map<UserDetailsDto>(user);

      return Ok(userDetails);
    }


  }
}