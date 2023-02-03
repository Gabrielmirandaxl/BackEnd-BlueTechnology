using System.Text.RegularExpressions;

namespace crud.Libs
{
  public static class ValidationEmail
  {
    public static bool validEmail(string email)
    {

      string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
         + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
         + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";


      return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }
  }
}
