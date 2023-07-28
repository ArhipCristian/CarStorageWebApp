using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarStorageWebApp.Models
{
    public class Car
    {        
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 1), Required]        
        public string? Brand { get; set; }

        [StringLength(50, MinimumLength = 1), Required]
        public string? Model { get; set; }

        [StringLength(200, MinimumLength = 1), Required]
        public string? Description { get; set; }

        [Display(Name = "Year"), DataType(DataType.Date)]
        public DateTime YearOfManufacturing { get; set; }

        [Range(1, 1000000), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
