using CleanArchitectureStudy.Application.Service;
using CleanArchitectureStudy.Infrastructure.Repository.DI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudy.Infrastructure.Repository.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CleanDbContext _db;
        public DbSet<T> dbSet;
        public Repository(CleanDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T item)
        {
            _db.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T item)
        {
            _db.Remove(item);
        }
    }
}
