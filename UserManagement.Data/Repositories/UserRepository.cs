using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagement.Domain;
using UserManagement.Data.Infrastructure;
using System.Data;

namespace UserManagement.Data
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        
    }
}
