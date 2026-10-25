using Access_Managment_API.DBContext;
using Access_Managment_API.Entities;
using Access_Managment_API.IRepository;

namespace Access_Managment_API.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AccessDBContext _dbContect;
        public AssetRepository(AccessDBContext db)
        {
            _dbContect = db;
        }
        public async Task<Asset?> GetByIdAsync(int id) {
            Asset? aset = await _dbContect.assets.FindAsync(id); 
            return aset;
        } 
        public async Task<Asset> AddAsync(Asset asset)
        {
            _dbContect.assets.Add(asset); 
            await _dbContect.SaveChangesAsync(); 
            return asset;
        }
    }
}
