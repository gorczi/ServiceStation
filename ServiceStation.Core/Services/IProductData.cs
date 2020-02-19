﻿using ServiceStation.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Core.Services
{
    public interface IProductData
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
    }
}
