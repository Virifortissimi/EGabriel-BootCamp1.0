﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GRP.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(long id);
        IQueryable<T> GetQueryable(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
