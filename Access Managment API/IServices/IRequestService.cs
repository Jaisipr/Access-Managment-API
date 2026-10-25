using Access_Managment_API.Entities;

namespace Access_Managment_API.IServices
{
    public interface IRequestService
    {
        Task<Access_Request> CreateRequestAsync(int assetId, int requesterId);
        Task<List<Access_Request>> GetPendingForApproverAsync(int approverId);
        Task ApproveAsync(int requestId, int approverId);
    }
}
