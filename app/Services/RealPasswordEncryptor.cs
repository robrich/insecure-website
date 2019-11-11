using InsecureWebsite.Data;
using Microsoft.AspNetCore.Identity;
using System;

namespace InsecureWebsite.Services
{
	public interface IRealPasswordEncryptor
	{
		string EncryptPassword(string password, string salt);
		string GetNewSalt();
	}

	public class RealPasswordEncryptor : IRealPasswordEncryptor
	{
		private readonly IPasswordHasher<User> passwordHasher;

		public RealPasswordEncryptor(IPasswordHasher<User> passwordHasher)
		{
			this.passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
		}

		public string GetNewSalt()
		{
			return Guid.NewGuid().ToString("N");
		}

		public string EncryptPassword(string password, string salt)
		{
			if (string.IsNullOrEmpty(password))
			{
				throw new ArgumentNullException(nameof(password));
			}
			if (string.IsNullOrEmpty(salt))
			{
				throw new ArgumentNullException(nameof(salt));
			}
			return passwordHasher.HashPassword(null, password+salt);
		}

	}
}
