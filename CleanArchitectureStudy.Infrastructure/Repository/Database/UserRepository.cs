using CleanArchitectureStudy.Application.Service;
using CleanArchitectureStudy.Domain.Models;
using CleanArchitectureStudy.Infrastructure.Repository.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudy.Infrastructure.Repository.Database
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly CleanDbContext _db;

        public UserRepository(CleanDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            _db.Update(user);
        }
    }
}
