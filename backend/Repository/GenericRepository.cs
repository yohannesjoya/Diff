using Backend.Contracts;
using Backend.Data;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Collections;

namespace Backend.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MongoContext _dbContext;

        public GenericRepository(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);

            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }


        public async Task<T> Get(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }
    }
}
