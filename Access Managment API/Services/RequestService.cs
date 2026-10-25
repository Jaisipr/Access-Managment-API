using Access_Managment_API.DBContext;
using Access_Managment_API.Entities;
using Access_Managment_API.IRepository;
using Access_Managment_API.IServices;

namespace Access_Managment_API.Services
{
    public class RequestService:IRequestService
    {
        private readonly AccessDBContext _dbContext;
        private readonly IRequestRepository _reqRepo;
        private readonly IApprovalRepository _approvalRepo;
        private readonly IUserAssetRepository _userAssetRepo;
        private readonly IAssetRepository _assetRepo;

        public RequestService( IRequestRepository reqRepo,IApprovalRepository approvalRepo,IUserAssetRepository userAssetRepo,
            IAssetRepository assetRepo,AccessDBContext dbcontext)
        {
            _reqRepo = reqRepo;
            _approvalRepo = approvalRepo;
            _userAssetRepo = userAssetRepo;
            _assetRepo = assetRepo;
            _dbContext = dbcontext;
        }

        public async Task<Access_Request> CreateRequestAsync(int assetId, int requesterId)
        {
            var asset = await _assetRepo.GetByIdAsync(assetId);
            var req = new Access_Request { AssetId = assetId, RequesterId = requesterId };
            return await _reqRepo.Create(req);
        }

        public async Task<List<Access_Request>> GetPendingForApproverAsync(int approverId)
        {

            List<Access_Request>  ResultList=await _reqRepo.GetPendingForApprover(approverId);
            return ResultList;
        }

        public async Task ApproveAsync(int requestId, int approverId)
        {
            var req = await _reqRepo.GetById(requestId);
            if (req.RequesterId == approverId)
            {
                throw new InvalidOperationException("Requester have no access to aprove their own requests");
            }

            var asset = await _assetRepo.GetByIdAsync(req.AssetId) ?? throw new InvalidOperationException("Asset not found");
            if (approverId != asset.Approver1Id && approverId != asset.Approver2Id)
            {
                throw new InvalidOperationException("User is not an approver for this asset");

            }

            if (await _approvalRepo.IsAlreadyApproved(requestId, approverId))
            {
                throw new InvalidOperationException("Approver has already approved this request");

            }

            await _approvalRepo.AddApproval(new Approval { RequestId = requestId, ApproverId = approverId });


            var Resultcount = await _approvalRepo.CountApprovals(requestId);
            if (Resultcount >= 2)
            {
                req.Status = "Approved";
                await _reqRepo.SaveAprovalChanges();

                await _userAssetRepo.GrantAccessAsync(new User_Asset_Asccess { UserId = req.RequesterId, AssetId = req.AssetId });
            }
        }

    }
}
