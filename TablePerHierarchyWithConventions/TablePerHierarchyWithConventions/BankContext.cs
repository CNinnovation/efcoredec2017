using Microsoft.EntityFrameworkCore;

namespace TablePerHierarchyWithConventions
{
    public class BankContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BankSample;trusted_connection=true";


        public DbSet<Payment> Payments { get; set; }
        public DbSet<CreditcardPayment> CreditcardPayments { get; set; }
        public DbSet<CashPayment> CashPayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
