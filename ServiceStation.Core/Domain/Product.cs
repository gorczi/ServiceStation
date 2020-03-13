using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStation.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(Category))]
        public Category Category { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
}
