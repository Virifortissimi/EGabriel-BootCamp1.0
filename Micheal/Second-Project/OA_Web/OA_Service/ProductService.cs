using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_DataAccess;
using OA_Repository;

namespace OA_Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ProductDetails> productDetailRepository;

        public ProductService(IRepository<Product>productRepository, IRepository<ProductDetails> productDetailRepository)
        {
            this.productRepository = productRepository;
            this.productDetailRepository = productDetailRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
           return productRepository.GetAll();       
        }

        public Product GetProduct(int id)
        {
            return productRepository.Get(id);   
        }

    }
}
