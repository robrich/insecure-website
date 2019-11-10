using System;

namespace InsecureWebsite.Services
{
	public interface IPasswordEncryptor
	{
		string EncryptPassword(string password, string salt);
		string GetNewSalt();
	}

	public class PasswordEncryptor : IPasswordEncryptor
	{
		/* for real:
		private readonly IPasswordHasher<User> passwordHasher;

		public PasswordEncryptor(IPasswordHasher<User> passwordHasher)
		{
			this.passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
		}
		*/

		public string GetNewSalt()
		{
			return Guid.NewGuid().ToString("N");
		}

		public string EncryptPassword(string password, string salt)
		{
			// for real: return passwordHasher.HashPassword(null, password);
			return password;
		}
	}
}
