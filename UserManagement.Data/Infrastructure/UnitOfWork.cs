using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserManagement.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private UserManagementContext dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected UserManagementContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
