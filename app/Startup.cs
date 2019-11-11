using InsecureWebsite.Data;
using InsecureWebsite.Models;
using InsecureWebsite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InsecureWebsite
{
	public class Startup
	{
		private readonly IConfiguration configuration;

		public Startup(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		
		public void ConfigureServices(IServiceCollection services)
		{
			string defaultConnection = this.configuration.GetConnectionString("DefaultConnection");

			AppSetings settings = new AppSetings();
			settings.DefaultConnection = defaultConnection;
			services.AddSingleton(settings);

			services.AddDbContext<InsecureWebsiteDbContext>(options => options.UseSqlServer(defaultConnection));

			services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
			services.AddSingleton<IRealPasswordEncryptor, RealPasswordEncryptor>();
			services.AddSingleton<INaivePasswordEncryptor, NaivePasswordEncryptor>();
			services.AddSingleton<ILoginStatusService, LoginStatusService>();

			services.AddControllersWithViews();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}

	}
}
