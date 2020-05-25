using System.ComponentModel.DataAnnotations;

namespace ServiceStation.Core.Shop
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
