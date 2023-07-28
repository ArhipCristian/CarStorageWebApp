using CarStorageWebApp.Data;
using CarStorageWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CarStorageWebAppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CarStorageWebAppContext>>()))
        {
            if (context == null || context.Car == null)
            {
                throw new ArgumentNullException("Null CarStorageWebAppContext");
            }

            // Look for any cars.
            if (context.Car.Any())
            {
                return; 
            }

            context.Car.AddRange(
                new Car
                {
                    Brand = "Honda",
                    Model = "Civic",
                    Description = "Popular compact car known for its reliability, practicality, and fuel efficiency. ",
                    YearOfManufacturing = DateTime.Parse("2022-1-1"),                   
                    Price = 23999.99M
                },

                new Car
                {
                    Brand = "Mercedes-Benz",
                    Model = "C300",
                    Description = "Luxury sedan that exudes elegance and sophistication. ",
                    YearOfManufacturing = DateTime.Parse("2018-1-1"),
                    Price = 34999.99M
                },

                new Car
                {
                    Brand = "BMW",
                    Model = "335i",
                    Description = "Dynamic and performance-oriented luxury sports sedan. ",
                    YearOfManufacturing = DateTime.Parse("2016-1-1"),
                    Price = 38999.99M
                },

                new Car
                {
                    Brand = "Chevrolet",
                    Model = "Silverado",
                    Description = "Rugged and dependable full-size pickup ",
                    YearOfManufacturing = DateTime.Parse("2020-1-1"),
                    Price = 28999.99M
                }

            );
            context.SaveChanges();
        }
    }
}