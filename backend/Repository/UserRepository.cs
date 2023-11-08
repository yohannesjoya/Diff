using Backend.Contracts;
using Backend.Data;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Backend.Repository
{
    public class UserRepository: GenericRepository<User>,IUserRepository
    {

        private readonly MongoContext _dbContext;

        public UserRepository(MongoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
