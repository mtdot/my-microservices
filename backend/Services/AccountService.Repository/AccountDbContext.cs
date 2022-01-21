using AccountService.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Repository
{
    public class AccountDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            // modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();

            modelBuilder.Entity<UserRole>().HasKey(i => new {i.UserId, i.RoleId});
        }
    }
}