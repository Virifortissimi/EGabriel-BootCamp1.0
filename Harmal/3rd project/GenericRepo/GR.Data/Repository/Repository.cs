﻿using GR.Data.Context;
using GR.Data.Entities;
using GR.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace GR.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public T Get(long id)
        {
            return entities.Find(id);
        }
        public IQueryable<T> GetQueryable(long id)
        {
            return entities.Where(x => x.Id == id).AsQueryable();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            SaveChange();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            SaveChange();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            SaveChange();
        }
        private void SaveChange()
        {
            context.SaveChanges();
        }
    }
}