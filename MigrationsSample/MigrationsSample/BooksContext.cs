using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationsSample
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=MigrationsSample;trusted_connection=true";
        //public BooksContext(DbContextOptions<BooksContext> options)
        //    : base(options)
        //{

        //}

        public BooksContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Book> Books { get; set; }
    }
}
