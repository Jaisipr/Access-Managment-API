using Access_Managment_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Access_Managment_API.DBContext
{
    public class AccessDBContext : DbContext
    {
        public AccessDBContext(DbContextOptions<AccessDBContext> options)
            : base(options)
        {
        }
        public DbSet<User> users => Set<User>();
        public DbSet<Approval> approvals => Set<Approval>();
        public DbSet<Access_Request> acessrequest => Set<Access_Request>();

        public DbSet<Asset> assets => Set<Asset>();
        public DbSet<User_Asset_Asccess> userAssetAccess => Set<User_Asset_Asccess>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approval>().HasKey(aproval => new { aproval.RequestId, aproval.ApproverId });

            modelBuilder.Entity<Access_Request>().HasOne(request => request.Asset).WithMany(assetreq => assetreq.AccessRequests).HasForeignKey(r => r.AssetId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
