using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceStation.Core.Shop
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

        public virtual AddressData Address { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}
