using Net6MongoDB.Models;

namespace Net6MongoDB.Repository
{
    public interface IUserRepo
    {
        Task CreateUser(User user);
        Task<List<User>> GetAll(); 
        Task<User> Get(string id);
        Task<User> Update(string Id, User user);
    }
}
