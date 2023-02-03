using crud.Model;

namespace crud.Libs
{
  public static class ValidationUser
  {

    public static void Validation(UserModel userModel)
    {

      if (userModel == null) throw new ArgumentException("Preencha todos os campos");
      if (string.IsNullOrWhiteSpace(userModel.Name)) throw new ArgumentException("Preencha o campo nome");
      if (string.IsNullOrWhiteSpace(userModel.Telefone)) throw new ArgumentException("Preencha o campo telefone");
      if (userModel.Telefone.Length != 14) throw new ArgumentException("Preencha corretamente o campo telefone");
      if (string.IsNullOrWhiteSpace(userModel.Cpf)) throw new ArgumentException("Preencha o campo cpf");
      if (userModel.Cpf.Length != 14) throw new ArgumentException("Preencha o campo cpf corretamente");
      if (string.IsNullOrWhiteSpace(userModel.Email)) throw new ArgumentException("Preencha o campo email");
      if (!ValidationEmail.validEmail(userModel.Email)) throw new ArgumentException("Email inválido");

    }

  }
}