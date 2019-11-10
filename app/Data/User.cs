using System.ComponentModel.DataAnnotations;

namespace InsecureWebsite.Data
{
	public class User
	{

		[Key]
		public int UserId { get; set; }

		[Required]
		[StringLength(200)]
		public string Username { get; set; }

		[Required]
		[StringLength(200)]
		public string Password { get; set; }

		[Required]
		[StringLength(32)]
		public string Salt { get; set; }
			   
		public bool IsAdmin { get; set; }

	}
}
