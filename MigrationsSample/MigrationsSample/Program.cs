using Microsoft.EntityFrameworkCore;
using System;

namespace MigrationsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateOrUpdateDatabase();

        }

        private static void CreateOrUpdateDatabase()
        {
            using (var context = new BooksContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
