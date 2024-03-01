using CleanArchitectureStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudy.Application.Service
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
        void Save();
    }
}
