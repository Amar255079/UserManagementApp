using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserManagement.Data.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private UserManagementContext dataContext;
    public UserManagementContext Get()
    {
        return dataContext ?? (dataContext = new UserManagementContext());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
