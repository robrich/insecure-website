namespace InsecureWebsite.Models
{
	public class LoginRequestModel
	{
		// If doing this for real, add validation:
		//[Required]
		//[StringLength(200)]
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
