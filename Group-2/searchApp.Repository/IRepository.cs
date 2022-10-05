using searchApp.Domain;

namespace searchApp.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(string text);
        Task Create(T entity);
    }
}