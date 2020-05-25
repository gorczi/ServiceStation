using Microsoft.AspNetCore.Identity;
using ServiceStation.Core.Shop;

namespace ServiceStation.Core.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public virtual AddressData Address { get; set; }
    }
}
