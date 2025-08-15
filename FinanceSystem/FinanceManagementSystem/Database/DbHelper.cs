using Oracle.ManagedDataAccess.Client;

namespace FinanceManagementSystem.Database
{
    public static class DbHelper
    {
        public static OracleConnection Open()
        {
            // Adjust service name to match your PDB name (XEPDB1, ORCLPDB1, etc.)
            string connString = "User Id=finance_user;Password=finance_pass;Data Source=localhost:1521/orclpdb;";

            var conn = new OracleConnection(connString);
            conn.Open();
            return conn;
        }
    }
}
