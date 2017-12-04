using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();
            AddLogging();
            CreateRecords();
            Query();
        }

        private static void AddLogging()
        {
            using (var context = new BooksContext())
            {
                IServiceProvider provider = context.GetInfrastructure<IServiceProvider>();

                ILoggerFactory logger = provider.GetService<ILoggerFactory>();
                logger.AddConsole();

            }
        }

        private static void Query()
        {
            using (var context = new BooksContext())
            {
                var books = context.Books.Where(b => b.Publisher == "Wrox Press");
                foreach (var b in books)
                {
                    Console.WriteLine($"{b.Title}");
                }
            }
        }

        private static void CreateRecords()
        {
            using (var context = new BooksContext())
            {
                context.Books.Add(new Book
                {
                    Title = "Professional C# 6",
                    Publisher = "Wrox Press"
                });
                context.Books.Add(new Book
                {
                    Title = "Enterprise Services",
                    Publisher = "AWL"
                });
                int changed = context.SaveChanges();
                Console.WriteLine($"{changed} records added");
            }
        }

        private static void CreateDatabase()
        {
            using (var context = new BooksContext())
            {
                bool created = context.Database.EnsureCreated();
                Console.WriteLine($"database created? {created}");
            }
        }
    }
}
