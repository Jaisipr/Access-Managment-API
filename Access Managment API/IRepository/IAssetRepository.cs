using Access_Managment_API.Entities;

namespace Access_Managment_API.IRepository
{
    public interface IAssetRepository
    {
        public  Task<Asset> AddAsync(Asset asset);

        public Task<Asset?> GetByIdAsync(int id);
    }
}
