// Controllers/AssetsController.cs
using Access_Managment_API.DTO;
using Access_Managment_API.IRepository;
using Access_Managment_API.IServices;
using Access_Managment_API.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/assets")]
public class AssetsController : ControllerBase
{
    private readonly IAssetService _assetService;
    private readonly IRequestService _requestService;
    private readonly IUserAssetRepository _userAssetRepo;
    public AssetsController(IAssetService assetService, IRequestService requestService, IUserAssetRepository userAssetRepo)
    {
        _assetService = assetService;
        _requestService = requestService;
        _userAssetRepo = userAssetRepo;
    }

    [HttpPost("createAsset")]
    public async Task<IActionResult> CreateAsset([FromBody] CreateAssetDto dto)
    {
        var asset = await _assetService.CreateAsset(dto.Name, dto.Approver1Id, dto.Approver2Id);
        return Ok("Asset Created With Asset ID: " + asset.AssetId);
    }



    [HttpPost("createRequest")]
    public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto dto)
    {
        var req = await _requestService.CreateRequestAsync(dto.AssetId, dto.RequesterId);
        return Ok("Request Created With Request ID: "+req.RequestId);
    }

    [HttpGet("pending/{approverId}")]
    public async Task<IActionResult> GetPending(int approverId)
    {
        var list = await _requestService.GetPendingForApproverAsync(approverId);
        return Ok(list);
    }

    [HttpPost("{requestId}/approve")]
    public async Task<IActionResult> Approve(int requestId, [FromBody] ApproveDto dto)
    {
        try
        {
            await _requestService.ApproveAsync(requestId, dto.ApproverId);
            return Ok("Approved Request");
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest( ex.Message);
        }
    }

    [HttpGet("asset/{assetId}/users")]
    public async Task<IActionResult> GetUsersWithAccess(int assetId)
    {
        var users = await _userAssetRepo.GetUsersWithAccess(assetId);
        return Ok(users);
    }

    [HttpGet("user/{userId}/assets")]
    public async Task<IActionResult> GetAssetsForUser(int userId)
    {
        var assets = await _userAssetRepo.GetAssetsForUser(userId);
        return Ok(assets);
    }
}
