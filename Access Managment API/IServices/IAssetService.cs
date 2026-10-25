using Access_Managment_API.Entities;

namespace Access_Managment_API.IServices
{
    public interface IAssetService
    {
        Task<Asset> CreateAsset(string name, int approver1Id, int approver2Id);
    }
}
