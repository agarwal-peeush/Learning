using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.ChainOfResponsibilityPattern
{
    public class ExpenseReport : IExpenseReport
    {
        public ExpenseReport(Decimal total)
        {
            Total = total;
        }

        public decimal Total { get; }
    }
}
