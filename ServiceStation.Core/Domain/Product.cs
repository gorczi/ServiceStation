using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStation.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Manufacturer { get; set; }


        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(Category))]
        public Category Category { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

    }
}
