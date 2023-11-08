using Backend.Contracts;
using Backend.Data;
using Backend.Entities;

namespace Backend.Repository
{
    public class OtpRepository : GenericRepository<OTP>,IOtpRepository
    {
        private readonly MongoContext _dbContext;

        public OtpRepository(MongoContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
