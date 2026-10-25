using Access_Managment_API.Entities;
using System.Threading.Tasks;

namespace Access_Managment_API.IRepository
{
    public interface IRequestRepository
    {
        public Task<Access_Request> Create(Access_Request request);
        public Task<List<Access_Request>> GetPendingForApprover(int approverId);
        public Task<Access_Request> GetById(int requestId);

        public Task SaveAprovalChanges();
    }
}
