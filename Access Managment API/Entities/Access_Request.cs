using System.ComponentModel.DataAnnotations;

namespace Access_Managment_API.Entities
{
    public class Access_Request
    {
        [Key]
        public int RequestId { get; set; }
        public int AssetId { get; set; }
        public int RequesterId { get; set; }
        public string Status { get; set; } = "In Progress";
        public Asset? Asset { get; set; }

    }
}
