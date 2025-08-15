using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using FinanceManagementSystem.Database;
using Oracle.ManagedDataAccess.Client;

namespace FinanceManagementSystem.Repositories
{
    public class AccountRepository
    {
        public void CreateAccountIfNotExists(string accountNumber, decimal openingBalance)
        {
            using var conn = DbHelper.Open();

            // Try insert; if PK exists, do nothing
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                MERGE INTO accounts a
                USING (SELECT :acc AS account_number, :bal AS balance FROM dual) s
                ON (a.account_number = s.account_number)
                WHEN NOT MATCHED THEN
                  INSERT (account_number, balance) VALUES (s.account_number, s.balance)";
            cmd.Parameters.Add(":acc", accountNumber);
            cmd.Parameters.Add(":bal", openingBalance);
            cmd.ExecuteNonQuery();
        }

        public void UpdateBalance(string accountNumber, decimal newBalance)
        {
            using var conn = DbHelper.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE accounts SET balance = :bal WHERE account_number = :acc";
            cmd.Parameters.Add(":bal", newBalance);
            cmd.Parameters.Add(":acc", accountNumber);
            var rows = cmd.ExecuteNonQuery();

            if (rows == 0)
                throw new InvalidOperationException("Account not found when updating balance.");
        }
    }
}
