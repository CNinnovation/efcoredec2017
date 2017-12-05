using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AmbientTX
{
    class Program
    {
        static void Main(string[] args)
        {
            AmbientTransactions();
            
        }

        private static void InnerTransaction()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                Transaction tx = Transaction.Current;
                ShowTxInfo("started inner scope", tx.TransactionInformation);
                scope.Complete();
            }
        }

        private static void AmbientTransactions()
        {

            using (var scope = new TransactionScope())
            {
                Transaction tx = Transaction.Current;
                ShowTxInfo("started", tx.TransactionInformation);

                tx.TransactionCompleted += (sender, e) =>
                {
                    ShowTxInfo("completed", tx.TransactionInformation);
                };

                InnerTransaction();

                scope.Complete();  // happy bit
            }  // Dispose - abort / rollback bei root tx
            Console.WriteLine("end");
        }

        private static void ShowTxInfo(string title, TransactionInformation txInfo)
        {
            Console.WriteLine(title);
            Console.WriteLine(txInfo.Status);
            Console.WriteLine($"local id: {txInfo.LocalIdentifier}");
            Console.WriteLine($"distributed id {txInfo.DistributedIdentifier}");
            Console.WriteLine();
        }
    }
}
