using System;
using System.Linq;

namespace TablePerHierarchyWithConventions
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();
            // CreateRecords();
            Query();
        }

        private static void Query()
        {
            using (var context = new BankContext())
            {
                var creditcards = context.Payments.OfType<CreditcardPayment>();
                foreach (var creditcard in creditcards)
                {
                    Console.WriteLine($"{creditcard.Amount} {creditcard.Text}");
                }

                var cashPayments = context.CashPayments;
                foreach (var cash in cashPayments)
                {
                    Console.WriteLine($"{cash.Text} {cash.Amount}");
                }
            }
        }

        private static void CreateRecords()
        {
            using (var context = new BankContext())
            {
                context.CreditcardPayments.Add(new CreditcardPayment
                {
                    Amount = 100,
                    CreditcardNumber = "4711123",
                    Text = "Gustav"
                });
                context.CashPayments.Add(new CashPayment
                {
                    Amount = 0.2,
                    Text = "Donald"
                });
                context.CashPayments.Add(new CashPayment
                {
                    Amount = 400000,
                    Text = "Dagobert"
                });

                context.SaveChanges();

            }
        }

        private static void CreateDatabase()
        {
            using (var context = new BankContext())
            {
                var created = context.Database.EnsureCreated();
            }
        }
    }
}
