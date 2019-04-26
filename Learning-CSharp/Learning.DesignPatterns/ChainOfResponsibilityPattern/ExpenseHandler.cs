using Learning.DesignPatterns.ChainOfResponsibilityPattern;

namespace Learning.DesignPatterns.ChainOfResponsibilityPattern
{
    internal class ExpenseHandler : IExpenseHandler
    {
        private readonly IExpenseApprover _ExpenseApprover;
        private IExpenseHandler _Next;

        public ExpenseHandler(IExpenseApprover expenseApprover)
        {
            _ExpenseApprover = expenseApprover;
            _Next = EndOfChainExpenseHandler.Instance;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            _Next = next;
        }

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            var response = _ExpenseApprover.ApproveResponse(expenseReport);
            if(response == ApprovalResponse.BeyondApprovalLimit)
            {
                return _Next.Approve(expenseReport);
            }
            return response;
        }
    }
}
