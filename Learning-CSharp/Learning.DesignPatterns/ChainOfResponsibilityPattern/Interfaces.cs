using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.ChainOfResponsibilityPattern
{
    /// <summary>
    /// ExpenseReport has total value of expense in Dollars/Cents
    /// </summary>
    public interface IExpenseReport
    {
        Decimal Total { get; }
    }
    /// <summary>
    /// ExpenseApprover is an employee who can approve expense
    /// </summary>
    public interface IExpenseApprover
    {
        ApprovalResponse ApproveResponse(IExpenseReport expenseReport);
    }

    public interface IExpenseHandler
    {
        ApprovalResponse Approve(IExpenseReport expenseReport);
        void RegisterNext(IExpenseHandler next);
    }

    public enum ApprovalResponse
    {
        Denied, 
        Approved,
        BeyondApprovalLimit,
    }
}
