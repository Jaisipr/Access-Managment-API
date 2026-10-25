using Access_Managment_API.DBContext;
using Access_Managment_API.Entities;
using Access_Managment_API.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Access_Managment_API.Repository
{
    public class UserAssetRepository : IUserAssetRepository
    {
        private readonly AccessDBContext _dbContext;
        public UserAssetRepository(AccessDBContext db) {
            _dbContext = db;
        } 

        public async Task GrantAccessAsync(User_Asset_Asccess UAA)
        {
            var exists = await _dbContext.userAssetAccess.AnyAsync(x => x.UserId == UAA.UserId && x.AssetId == UAA.AssetId);
            
            if (!exists) { 
                _dbContext.userAssetAccess.Add(UAA); await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<int>> GetUsersWithAccess(int assetId)
        {
            return await _dbContext.userAssetAccess.Where(x => x.AssetId == assetId).Select(x => x.UserId).ToListAsync();

        }

        public async Task<List<int>> GetAssetsForUser(int userId)
        {
            return await _dbContext.userAssetAccess.Where(x => x.UserId == userId).Select(x => x.AssetId).ToListAsync();


        }

    }
}
