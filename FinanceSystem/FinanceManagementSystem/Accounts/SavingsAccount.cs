using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Accounts
{
    // Cannot be inherited further
    public sealed class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance) { }

        public override void ApplyTransaction(Transaction transaction)
        {
            if (transaction.Amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
                return;
            }

            Balance -= transaction.Amount;
            Console.WriteLine($"Transaction applied. New Balance: {Balance:C}");
        }
    }
}
