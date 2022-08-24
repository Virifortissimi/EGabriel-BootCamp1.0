using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OA_DataAccess;

namespace OA_Repository
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            new ProductMap(modelBuilder.Entity<Product>()); 
            new ProductDetailMap(modelBuilder.Entity<ProductDetails>()); 
        }
    }
}
