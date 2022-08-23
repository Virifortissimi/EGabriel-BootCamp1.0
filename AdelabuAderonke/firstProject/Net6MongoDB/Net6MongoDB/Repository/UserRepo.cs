using MongoDB.Entities;
using Net6MongoDB.Models;

namespace Net6MongoDB.Repository
{
    public class UserRepo:IUserRepo
    {
        public async Task CreateUser(User user)
        {
            await user.SaveAsync();

        }
        public async Task<List<User>>GetAll()
        {
            var users = await DB.Find<User>()
                        .Match(_ => true)
                        .ExecuteAsync();

            return users;

        }
        public async Task<User> Get(string Id)
        {
            var users = await DB.Find<User>()
                        .Match(x=>x.ID ==Id)
                        .ExecuteFirstAsync();

            return users;

        }
        public async Task<User> Update(string Id, User user)
        {
            var updatedUser = await DB.UpdateAndGet<User>()
                        .MatchID(Id)
                        .ExecuteAsync();

            return updatedUser;

        }
    }
}
