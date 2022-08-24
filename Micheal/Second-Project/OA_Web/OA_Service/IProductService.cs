using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_DataAccess;

namespace OA_Service
{
    public  interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id); 
    }
}
