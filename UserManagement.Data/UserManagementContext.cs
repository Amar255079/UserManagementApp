using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using UserManagement.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Data
{
    public class UserManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.ID).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class UserManagementContextInitializer : DropCreateDatabaseIfModelChanges<UserManagementContext>
    {
        protected override void Seed(UserManagementContext context)
        {

        }
    }
}