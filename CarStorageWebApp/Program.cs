using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarStorageWebApp.Data;
using CarStorageWebApp.Models;
using RazorPagesMovie.Models;

namespace CarStorageWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);            
            
            //Adding the databse context
            builder.Services.AddDbContext<CarStorageWebAppContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CarStorageWebAppContext") ?? throw new InvalidOperationException("Connection string 'CarStorageWebAppContext' not found.")));  

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.WebHost.UseStaticWebAssets();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                //Seeding the database with initial data
                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");                
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}