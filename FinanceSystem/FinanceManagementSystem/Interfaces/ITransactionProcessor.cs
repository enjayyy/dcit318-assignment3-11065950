using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Interfaces
{
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}
