using System;

namespace InsecureWebsite.Services
{
	public interface INaivePasswordEncryptor
	{
		string EncryptPassword(string password, string salt);
		string GetNewSalt();
	}

	public class NaivePasswordEncryptor : INaivePasswordEncryptor
	{

		public string GetNewSalt()
		{
			return Guid.NewGuid().ToString("N");
		}

		/// <summary>
		/// For demonstration purposes only, this allows us to experiment with passwords from the database
		/// </summary>
		public string EncryptPassword(string password, string salt)
		{
			return password;
		}
	}
}
