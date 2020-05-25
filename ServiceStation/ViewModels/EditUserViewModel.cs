using ServiceStation.Core.Shop;
using System.ComponentModel.DataAnnotations;

namespace ServiceStation.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter the user name")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the user email")]
        public string Email { get; set; }

        public AddressData Address { get; set; }
    }
}
