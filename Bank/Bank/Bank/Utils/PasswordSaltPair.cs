namespace Bank.Utils
{
  public class PasswordSaltPair
  {
    public string Password { get; }

    public string Salt { get; }

    public PasswordSaltPair(string password, string salt)
    {
      Password = password;
      Salt = salt;
    }
  }
}
