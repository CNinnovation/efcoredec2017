using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample1
{
    public class BooksContext : DbContext
    {

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
