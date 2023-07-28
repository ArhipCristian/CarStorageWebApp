using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarStorageWebApp.Models;

namespace CarStorageWebApp.Data
{
    public class CarStorageWebAppContext : DbContext
    {
        public CarStorageWebAppContext (DbContextOptions<CarStorageWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<CarStorageWebApp.Models.Car> Car { get; set; } = default!;
    }
}
