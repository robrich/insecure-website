using InsecureWebsite.Data;
using InsecureWebsite.Models;
using InsecureWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace InsecureWebsite.Controllers
{
	public class Login3Controller : Controller
	{
		private readonly InsecureWebsiteDbContext db;
		private readonly IPasswordEncryptor passwordEncryptor;
		private readonly ILoginStatusService loginStatusService;

		public Login3Controller(InsecureWebsiteDbContext insecureWebsiteDbContext, IPasswordEncryptor passwordEncryptor, ILoginStatusService loginStatusService)
		{
			this.db = insecureWebsiteDbContext ?? throw new ArgumentNullException(nameof(insecureWebsiteDbContext));
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

			User dbUser = (
				from u in db.User
				where u.Username == model.Username
				select u
			).FirstOrDefault();

			if (dbUser != null) { 
				user = new CurrentUserModel
				{
					Username = dbUser.Username,
					IsAdmin = dbUser.IsAdmin
				};
				string encryptedPassword = passwordEncryptor.EncryptPassword(model.Password, dbUser.Salt);

				if (string.Equals(encryptedPassword, dbUser.Password, StringComparison.InvariantCultureIgnoreCase))
				{
					user.IsAuthenticated = true;
				}
			}

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
