using Microsoft.EntityFrameworkCore;

namespace InsecureWebsite.Data
{
	public class InsecureWebsiteDbContext : DbContext
	{
		public InsecureWebsiteDbContext(DbContextOptions<InsecureWebsiteDbContext> options)
			: base(options)
		{ }

		// By convention this is also the name of the table:
		public DbSet<User> User { get; set; }

	}
}
