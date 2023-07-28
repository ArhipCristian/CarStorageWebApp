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
            builder.Services.AddDbContext<CarStorageWebAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CarStorageWebAppContext") ?? throw new InvalidOperationException("Connection string 'CarStorageWebAppContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.WebHost.UseStaticWebAssets();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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