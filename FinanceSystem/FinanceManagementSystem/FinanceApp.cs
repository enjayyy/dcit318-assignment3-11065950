using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using FinanceManagementSystem.Models;
using FinanceManagementSystem.Accounts;
using FinanceManagementSystem.Processors;
using FinanceManagementSystem.Repositories;

namespace FinanceManagementSystem
{
    public class FinanceApp
    {
        private readonly List<Transaction> _transactions = new();
        private readonly AccountRepository _accountRepo = new();
        private readonly TransactionRepository _txRepo = new();

        public void Run()
        {
            var account = new SavingsAccount("ACC123", initialBalance: 1000m);

            _accountRepo.CreateAccountIfNotExists(account.AccountNumber, account.Balance);

            var t1 = new Transaction(1, DateTime.Now, 100m, "Groceries");
            var t2 = new Transaction(2, DateTime.Now, 200m, "Utilities");
            var t3 = new Transaction(3, DateTime.Now, 50m, "Entertainment");

            var momo = new MobileMoneyProcessor();
            var bank = new BankTransferProcessor();
            var crypto = new CryptoWalletProcessor();

            momo.Process(t1);
            bank.Process(t2);
            crypto.Process(t3);

            ApplyAndPersist(account, t1);
            ApplyAndPersist(account, t2);
            ApplyAndPersist(account, t3);

            _transactions.AddRange(new[] { t1, t2, t3 });

            Console.WriteLine($"\nFinal account balance: {account.Balance:C}");
        }

        private void ApplyAndPersist(SavingsAccount account, Transaction tx)
        {
            Console.WriteLine($"\nApplying {tx.Category} ({tx.Amount:C})...");
            var before = account.Balance;

            account.ApplyTransaction(tx);

            if (account.Balance < before)
            {
                _txRepo.Insert(tx, account.AccountNumber);
                _accountRepo.UpdateBalance(account.AccountNumber, account.Balance);
            }
        }
    }
}

