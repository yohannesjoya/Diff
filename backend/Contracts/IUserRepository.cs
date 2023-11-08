using Backend.Entities;

namespace Backend.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
