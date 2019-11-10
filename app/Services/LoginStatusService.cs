using InsecureWebsite.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace InsecureWebsite.Services
{
	public interface ILoginStatusService
	{
		CurrentUserModel GetUserCookie(HttpRequest request);
		void SetUserCookie(CurrentUserModel user, HttpResponse response);
		void ClearUserCookie(HttpResponse response);
	}

	/// <summary>
	/// For demo only. Don't do this. Use ASP.NET Identity instead.
	/// </summary>
	public class LoginStatusService : ILoginStatusService
	{
		private const string COOKIE_NAME = "InsecureWebsite";

		public CurrentUserModel GetUserCookie(HttpRequest request)
		{
			CurrentUserModel model = null;
			if (request.Cookies.ContainsKey(COOKIE_NAME))
			{
				try
				{
					model = JsonSerializer.Deserialize<CurrentUserModel>(request.Cookies[COOKIE_NAME]);
				}
				catch
				{
					model = null; // ignore bad cookie
				}
			}
			if (model == null)
			{
				model = new CurrentUserModel
				{
					IsAuthenticated = false
				};
			}
			else
			{
				model.IsAuthenticated = !string.IsNullOrEmpty(model.Username);
			}

			return model;
		}

		public void SetUserCookie(CurrentUserModel user, HttpResponse response)
		{
			string data = JsonSerializer.Serialize(user);
			response.Cookies.Append(COOKIE_NAME, data);
		}

		public void ClearUserCookie(HttpResponse response)
		{
			response.Cookies.Delete(COOKIE_NAME);
		}

	}
}
