using InsecureWebsite.Data;
using InsecureWebsite.Models;
using InsecureWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace InsecureWebsite.Controllers
{
	public class Login1Controller : Controller
	{
		private readonly AppSetings settings;
		private readonly IPasswordEncryptor passwordEncryptor;
		private readonly ILoginStatusService loginStatusService;

		public Login1Controller(AppSetings settings, IPasswordEncryptor passwordEncryptor, ILoginStatusService loginStatusService)
		{
			this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
			this.passwordEncryptor = passwordEncryptor ?? throw new ArgumentNullException(nameof(passwordEncryptor));
			this.loginStatusService = loginStatusService ?? throw new ArgumentNullException(nameof(loginStatusService));
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View(new LoginResponseModel());
		}

		[HttpPost]
		public IActionResult Index(LoginRequestModel model)
		{
			CurrentUserModel user = null;

			string sql = $"select UserId, Password, Salt, IsAdmin from dbo.[User] where Username = '{model.Username}'";
			using SqlConnection conn = new SqlConnection(settings.DefaultConnection);
			conn.Open();
			using IDbCommand cmd = new SqlCommand(sql, conn);
			using IDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				user = new CurrentUserModel
				{
					Username = model.Username,
					IsAdmin = (bool)reader["IsAdmin"]
				};
				string dbPassword = (string)reader["Password"];
				string salt = (string)reader["Salt"];
				string encryptedPassword = passwordEncryptor.EncryptPassword(model.Password, salt);

				if (string.Equals(encryptedPassword, dbPassword, StringComparison.InvariantCultureIgnoreCase))
				{
					user.IsAuthenticated = true;
				}
			}
			conn.Close();

			if (user?.IsAuthenticated ?? false)
			{
				loginStatusService.SetUserCookie(user, this.Response);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				// Show failed message
				return View(new LoginResponseModel
				{
					Message = "invalid username / password"
				});
			}
		}

	}
}
