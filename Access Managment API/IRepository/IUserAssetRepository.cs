using Access_Managment_API.Entities;

namespace Access_Managment_API.IRepository
{
    public interface IUserAssetRepository
    {
        public Task GrantAccessAsync(User_Asset_Asccess UAA);

        Task<List<int>> GetUsersWithAccess(int assetId);
        Task<List<int>> GetAssetsForUser(int userId);
    }
}
