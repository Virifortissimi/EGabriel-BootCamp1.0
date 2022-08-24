﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OA_DataAccess;

namespace OA_Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> entities;
        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();    
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable(); 
        }
    }
    
}
