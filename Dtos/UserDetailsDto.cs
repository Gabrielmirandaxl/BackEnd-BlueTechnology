namespace crud.Dtos
{
  public class UserDetailsDto
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Cpf { get; set; }
    public DateTime CreateRegistration { get; set; }
    public DateTime UpdateRegistration { get; set; }
  }
}