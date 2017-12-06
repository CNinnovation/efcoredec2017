using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Sample1.Tests
{
    public class RunServiceTest
    {
        public RunServiceTest()
        {
            InitContext();
        }
        private BooksContext _booksContext;

        private void InitContext()
        {
            var builder = new DbContextOptionsBuilder<BooksContext>()
                .UseInMemoryDatabase("BooksDB");

            var context = new BooksContext(builder.Options);
            var books = Enumerable.Range(1, 10)
                .Select(i => new Book { BookId = i, Title = $"Sample{i}", Publisher = "Wrox Press" });
            context.Books.AddRange(books);
            int changed = context.SaveChanges();
            _booksContext = context;
        }

        [Fact]
        public void TestQuery()
        {
            int expected = 10;
            var service = new RunService(_booksContext);
            var result = service.QueryBooks();

            Assert.Equal(expected, result.Count());
        }

        //[Fact]
        //public void TestCreateRecords()
        //{
        //    int expected = 12;
        //    var service = new RunService(_booksContext);
        //    service.CreateRecords();
        //    int result = _booksContext.Books.Count();

        //    Assert.Equal(expected, result);
        //}
    }
}
