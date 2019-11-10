using InsecureWebsite.Models;
using InsecureWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InsecureWebsite.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILoginStatusService loginStatusService;

		public HomeController(ILoginStatusService loginStatusService)
		{
			this.loginStatusService = loginStatusService ?? throw new ArgumentNullException(nameof(loginStatusService));
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Logout()
		{
			this.loginStatusService.ClearUserCookie(this.Response);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Hints()
		{
			return View();
		}

	}
}
