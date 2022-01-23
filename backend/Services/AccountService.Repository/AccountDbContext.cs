using System;
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
            var idUser1 = Guid.NewGuid();
            var idUser2 = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new[]
            {
                new User
                {
                    Id = idUser1,
                    Name = "User1",
                    Age = 31
                }, new User
                {
                    Id = idUser2,
                    Name = "User2",
                    Age = 31
                }
            });
            // modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            var adminRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();
            modelBuilder.Entity<Role>().HasData(new[]
            {
                new Role
                {
                    Id = adminRoleId,
                    Name = "Admin"
                },
                new Role
                {
                    Id = userRoleId,
                    Name = "User",
                } 
            });
            
            modelBuilder.Entity<UserRole>().HasKey(i => new {i.UserId, i.RoleId});
            modelBuilder.Entity<UserRole>().HasData(new[]
            {
                new UserRole
                {
                    UserId = idUser1,
                    RoleId = adminRoleId
                },
                new UserRole
                {
                    UserId = idUser2,
                    RoleId = userRoleId
                }
            });
        }
    }
}