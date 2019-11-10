using InsecureWebsite.Models;
using InsecureWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsecureWebsite.Helpers
{
	public static class CurrentUserHelper
	{
		private static ILoginStatusService loginStatusService = new LoginStatusService();

		public static CurrentUserModel GetCurrentUser(this IHtmlHelper _, HttpRequest request) => loginStatusService.GetUserCookie(request);

	}
}
