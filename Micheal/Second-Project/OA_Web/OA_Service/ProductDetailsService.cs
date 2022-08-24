using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_DataAccess;
using OA_Repository;

namespace OA_Service
{
    public class ProductDetailsService: IProductDetailsService
    {
        private readonly IRepository<ProductDetails> productDetailRepository;

        public ProductDetailsService(IRepository<ProductDetails> productDetailRepository )
        {
            this.productDetailRepository = productDetailRepository;
        }

        public ProductDetails GetProductDetail(int id)
        {
           return productDetailRepository.Get( id );    
        }
    }
}
