using CleanArchitectureStudy.Application.Service;
using CleanArchitectureStudy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudy.Infrastructure.Repository.DI
{
    public class CleanDbContext : DbContext, ICleanDbContext
    {
        public CleanDbContext(DbContextOptions<CleanDbContext>  options) : base(options) { }    
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { userId = 1, userEmail = "admin@gmail.com", userName = "admin", passWord = "123456"},
                new User { userId = 101, userEmail = "guest1@gmail.com", userName = "guest1", passWord = "12345678" },
                new User { userId = 102, userEmail = "guest2@gmail.com", userName = "guest2", passWord = "12345678" }
                );
        }
    }
}
