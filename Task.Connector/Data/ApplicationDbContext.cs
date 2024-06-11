using Microsoft.EntityFrameworkCore;
using Task.Connector.Data.Models;
using Task.Connector.Helpers;

namespace Task.Connector.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<User> User { get; set; }
        public DbSet<PasswordEntity> Passwords { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && _connectionString != null)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }
        public override int SaveChanges()
        {
            ApplyDefaultValues();
            return base.SaveChanges();
        }
        private void ApplyDefaultValues()
        {
            foreach (var entry in ChangeTracker.Entries<User>())
            {
                if (entry.State == EntityState.Added)
                {
                    DefaultUserValueSetter.SetDefaultValues(entry.Entity);
                }
            }
        }
    }
}
