using System;
using System.Security.Cryptography;
using System.Text;

namespace Bank.Utils
{
  public class CredentialsManager
  {
    public PasswordSaltPair HashPassword(string rawPassword)
    {
      var salt = GetSalt(32);
      var hashedPassword = HashPasswordInternal(rawPassword, salt);

      return new PasswordSaltPair(Convert.ToBase64String(hashedPassword), Convert.ToBase64String(salt));
    }

    public bool VerifyHashedPassword(PasswordSaltPair existingPair, string rawPassword)
    {
      var saltBytes = Convert.FromBase64String(existingPair.Salt);

      var newPassword = Convert.ToBase64String(HashPasswordInternal(rawPassword, saltBytes));

      return existingPair.Password == newPassword;
    }
    
    private byte[] GetSalt(int saltSizeInBytes)
    {
      var salt = new byte[saltSizeInBytes];

      using (var rngScp = new RNGCryptoServiceProvider())
      {
        rngScp.GetBytes(salt);
      }

      return salt;
    }

    private byte[] HashPasswordInternal(string rawPassword, byte[] salt)
    {
      var passwordBytes = Encoding.UTF8.GetBytes(rawPassword);

      using (var derivedBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 10000))
        return derivedBytes.GetBytes(32);
    }
  }
}
