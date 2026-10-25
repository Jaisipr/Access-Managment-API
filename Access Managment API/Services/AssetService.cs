using Access_Managment_API.Entities;
using Access_Managment_API.IRepository;
using Access_Managment_API.IServices;

namespace Access_Managment_API.Services
{
    public class AssetService: IAssetService
    {
        private readonly IAssetRepository _repo;
        public AssetService(IAssetRepository repo) => _repo = repo;

        public async Task<Asset> CreateAsset(string name, int approver1Id, int approver2Id)
        {
            if (approver1Id == approver2Id)
            {
                throw new ArgumentException("Two approver shpuld be different");
            }

            var asset = new Asset { AssetName = name, Approver1Id = approver1Id, Approver2Id = approver2Id };
            return await _repo.AddAsync(asset);
        }
    }
}
