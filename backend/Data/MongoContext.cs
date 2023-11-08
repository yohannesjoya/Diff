using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Backend.Data
{
    public class MongoContext : DbContext
    {


        public MongoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToCollection("users");
            modelBuilder.Entity<OTP>().ToCollection("otps");

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> Users { get; init; }
        public DbSet<OTP> OTPs { get; init; }
    }
}

