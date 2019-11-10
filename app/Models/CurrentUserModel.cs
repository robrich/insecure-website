namespace InsecureWebsite.Models
{
	public class CurrentUserModel
	{
		public bool IsAuthenticated { get; set; }
		public string Username { get; set; }
		public bool IsAdmin { get; set; }
	}
}
