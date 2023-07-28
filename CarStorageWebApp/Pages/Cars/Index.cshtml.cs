using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarStorageWebApp.Data;
using CarStorageWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarStorageWebApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarStorageWebApp.Data.CarStorageWebAppContext _context;

        public IndexModel(CarStorageWebApp.Data.CarStorageWebAppContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? YearsOfManufacturing { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime CarYearOfManufacturing { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<DateTime> yearQuery = from m in _context.Car
                                            orderby m.YearOfManufacturing
                                            select m.YearOfManufacturing;
            var cars = from m in _context.Car
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                cars = cars.Where(s => s.Brand.Contains(SearchString));
            }

            if (CarYearOfManufacturing != DateTime.MinValue)
            {
                cars = cars.Where(x => x.YearOfManufacturing == CarYearOfManufacturing);
            }

            YearsOfManufacturing = new SelectList(await yearQuery.Distinct().ToListAsync());
            Car = await cars.ToListAsync();
        }
    }
}
