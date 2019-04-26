namespace Learning.DesignPatterns.ChainOfResponsibilityPattern
{
    public class Employee : IExpenseApprover
    {
        private readonly decimal _ApprovalLimit;

        public Employee(string name, decimal approvalLimit)
        {
            Name = name;
            _ApprovalLimit = approvalLimit;
        }

        public string Name { get; }

        public ApprovalResponse ApproveResponse(IExpenseReport expenseReport)
        {
            return expenseReport.Total > _ApprovalLimit
                ? ApprovalResponse.BeyondApprovalLimit
                : ApprovalResponse.Approved;

        }
    }
}
