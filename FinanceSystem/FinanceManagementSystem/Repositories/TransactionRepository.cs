using FinanceManagementSystem.Database;
using FinanceManagementSystem.Models;
using Oracle.ManagedDataAccess.Client;

namespace FinanceManagementSystem.Repositories
{
    public class TransactionRepository
    {
        public void Insert(Transaction tx, string accountNumber)
        {
            using var conn = DbHelper.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO transactions (transaction_date, amount, category, account_number)
                VALUES (:dt, :amt, :cat, :acc)";
            cmd.Parameters.Add(":dt", tx.Date);
            cmd.Parameters.Add(":amt", tx.Amount);
            cmd.Parameters.Add(":cat", tx.Category);
            cmd.Parameters.Add(":acc", accountNumber);
            cmd.ExecuteNonQuery();
        }
    }
}
