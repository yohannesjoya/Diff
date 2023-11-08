



using Backend.Contracts;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
      
        private IUserRepository _userRepository;
        private IOtpRepository _otpRepository;


        private readonly MongoContext _dbContext;

        public UnitOfWork(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);
        public IOtpRepository OtpRepository => _otpRepository ??= new OtpRepository(_dbContext);


        public void Dispose()
        {

            _dbContext.Dispose();
            GC.SuppressFinalize(this);

        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
