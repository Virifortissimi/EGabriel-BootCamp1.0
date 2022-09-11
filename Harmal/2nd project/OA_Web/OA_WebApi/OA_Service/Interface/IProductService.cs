﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.Interface
{
    public interface IProductService
    {
        IEnumerable<OA_DataAccess.Product> GetProduct();
        OA_DataAccess.Product GetProduct(int id);
    }
}
