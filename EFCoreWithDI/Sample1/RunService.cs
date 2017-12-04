using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Sample1
{
    public class RunService
    {
        private readonly BooksContext _context;
        public RunService(BooksContext booksContext)
        {
            _context = booksContext;
        }
        public void AddLogging()
        {
            IServiceProvider provider = _context.GetInfrastructure<IServiceProvider>();

            ILoggerFactory logger = provider.GetService<ILoggerFactory>();
            logger.AddConsole();
        }

        public void Query()
        {
            var books = _context.Books.Where(b => b.Publisher == "Wrox Press");
            foreach (var b in books)
            {
                Console.WriteLine($"{b.Title}");
            }
        }


        public void CreateRecords()
        {
            _context.Books.Add(new Book
            {
                Title = "Professional C# 6",
                Publisher = "Wrox Press"
            });
            _context.Books.Add(new Book
            {
                Title = "Enterprise Services",
                Publisher = "AWL"
            });
            int changed = _context.SaveChanges();
            Console.WriteLine($"{changed} records added");
        }


        public void CreateDatabase()
        {
            bool created = _context.Database.EnsureCreated();
            Console.WriteLine($"database created? {created}");

        }
    }
}
