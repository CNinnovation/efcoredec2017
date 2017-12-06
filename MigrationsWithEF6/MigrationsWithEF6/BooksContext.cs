using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsWithEF6
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=EF6;trusted_connection=true";
        public BooksContext()
            : base(ConnectionString)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
