using Microsoft.EntityFrameworkCore;
using RunGroupWeb.Data;
using RunGroupWeb.Interfaces;
using RunGroupWeb.Repository;

namespace RunGroupWeb
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddScoped<IClubRepository,ClubRepository>();
            builder.Services.AddScoped<IRaceRepository, RaceRepository>();

            // Db Connection
            builder.Services.AddDbContext<ApplicationDataContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			var app = builder.Build();

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
				Seed.SeedData(app);
                
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
