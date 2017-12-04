using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sample1
{
    class Program
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BooksSample2;trusted_connection=true";

        static void Main(string[] args)
        {
            ConfigureServices();
            using (var scope = ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<RunService>();
                service.AddLogging();
                service.CreateDatabase();
                service.CreateRecords();
                service.Query();
            }

        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<BooksContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
            services.AddScoped<RunService>();
            ApplicationServices = services.BuildServiceProvider();
        }

        public static IServiceProvider ApplicationServices { get; private set; }


    }
}
