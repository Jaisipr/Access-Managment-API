using Access_Managment_API.DBContext;
using Access_Managment_API.Entities;
using Access_Managment_API.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Access_Managment_API.Repository
{
    public class RequestRepository:IRequestRepository
    {
        private readonly AccessDBContext _dbContext;
        public RequestRepository(AccessDBContext db)
        {
            _dbContext = db;
        }

        public async Task<Access_Request> Create(Access_Request req)
        {
            _dbContext.acessrequest.Add(req);
            await _dbContext.SaveChangesAsync();
            return req;
        }

        public async Task<Access_Request?> GetById(int id)
        {
           return  await _dbContext.acessrequest.FindAsync(id);

        }

        public async Task<List<Access_Request>> GetPendingForApprover(int approverId)
        {
            var pendingRequests = await _dbContext.acessrequest.Include(req => req.Asset).Where(req =>req.Status != null &&req.Status.Trim().ToLower() == "in progress" && 
                            req.Asset != null &&(req.Asset.Approver1Id == approverId || req.Asset.Approver2Id == approverId)).ToListAsync();
            return pendingRequests;
        }

        public async Task SaveAprovalChanges()
        {
            await _dbContext.SaveChangesAsync();

        }
    }
}
