using Microsoft.AspNetCore.Identity;
using ServiceStation.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStation.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public virtual AddressData Address { get; set; }
    }
}
