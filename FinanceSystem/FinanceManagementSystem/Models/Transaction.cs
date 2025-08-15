using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace FinanceManagementSystem.Models
{
    // Immutable transaction data
    public record Transaction(int Id, DateTime Date, decimal Amount, string Category);
}
