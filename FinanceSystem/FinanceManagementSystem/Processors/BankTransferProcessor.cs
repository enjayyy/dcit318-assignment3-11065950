using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManagementSystem.Interfaces;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Processors
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Bank Transfer] Processed {transaction.Amount:C} for {transaction.Category}");
        }
    }
}
