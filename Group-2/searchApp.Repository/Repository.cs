using Microsoft.EntityFrameworkCore;
using searchApp.Domain;

namespace searchApp.Repository
{
    public class Repository<T> : IRepository<T> where T :  BaseEntity
    {
        private readonly AppContext _context;

        private readonly DbSet<T> _entities;

        public Repository(AppContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task Create(T entity)
        {
    
            ArgumentNullException.ThrowIfNull(entity);
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public T Get(string text)
        {
            return _entities.FirstOrDefault<T>(t => t.Text == text)!;
        }
    }
}