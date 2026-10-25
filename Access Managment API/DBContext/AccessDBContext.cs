using Access_Managment_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Access_Managment_API.DBContext
{
    public class AccessDBContext: DbContext
    {
        AccessDBContext(DbContextOptions<AccessDBContext> options): base(options) { }

        public DbSet<User> users => Set<User>();
        public DbSet<Approval> approvals => Set<Approval>();
        public DbSet<Access_Request> acessrequest => Set<Access_Request>();
        
        public DbSet<Asset> assets => Set<Asset>();
        public  DbSet<User_Asset_Asccess> userAssetAccess => Set<User_Asset_Asccess>();


        
    }
}
