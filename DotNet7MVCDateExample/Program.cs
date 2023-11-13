using DateExample.DataModel;
using Microsoft.EntityFrameworkCore;

namespace DotNet7MVCDateExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("DateContextConnection")
                        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            // Must be done before build
            builder.Services.AddDbContext<DateContext>(options =>
              options.UseSqlServer(connectionString));

            var app = builder.Build();

   
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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