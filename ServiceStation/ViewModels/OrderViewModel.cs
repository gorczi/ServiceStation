using ServiceStation.Core.Shop;
using System.ComponentModel.DataAnnotations;

namespace ServiceStation.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Please enter the user name")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter the user email")]
        public string Email { get; set; }

        [Required]
        public AddressData Address { get; set; }
    }
}
