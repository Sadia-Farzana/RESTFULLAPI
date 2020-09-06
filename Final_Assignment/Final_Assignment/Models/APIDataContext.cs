using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class APIDataContext: DbContext
    {
        public APIDataContext()
        {
            Database.SetInitializer<APIDataContext>(new DropCreateDatabaseIfModelChanges<APIDataContext>());

        }

        virtual public DbSet<Comment> Comments { get; set; }
        virtual public DbSet<Post> Posts { get; set; }

    }
}