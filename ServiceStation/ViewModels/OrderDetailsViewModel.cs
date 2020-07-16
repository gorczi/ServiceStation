using ServiceStation.Core.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceStation.ViewModels
{
    public class OrderDetailsViewModel
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public AddressData Address { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        public DateTime OrderPlaced { get; set; }

        public decimal OrderTotal { get; set; }
    }
}
