using Access_Managment_API.Entities;

namespace Access_Managment_API.IRepository
{
    public interface IApprovalRepository
    {
        public Task<bool> IsAlreadyApproved(int requestId, int approverId);
        public Task AddApproval(Approval approval);

        public Task<int> CountApprovals(int requestID);

    }
}
