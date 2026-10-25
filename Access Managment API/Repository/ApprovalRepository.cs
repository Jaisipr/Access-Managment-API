using Access_Managment_API.DBContext;
using Access_Managment_API.Entities;
using Access_Managment_API.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Access_Managment_API.Repository
{
    public class ApprovalRepository : IApprovalRepository
    {

        private readonly AccessDBContext _dbContext;
        public ApprovalRepository(AccessDBContext db)
        {
            _dbContext = db;

        }

        public async Task<bool> IsAlreadyApproved(int requestId, int approverId)
        {

            return await _dbContext.approvals.AnyAsync(aproval => aproval.RequestId == requestId && aproval.ApproverId == approverId);
        }

        public async Task<int> CountApprovals(int requestId)
        {
            return await _dbContext.approvals.CountAsync(aproval => aproval.RequestId == requestId);
        }

        public async Task AddApproval(Approval approval)
        {
            _dbContext.approvals.Add(approval);
            await _dbContext.SaveChangesAsync();
        }
    }
}
