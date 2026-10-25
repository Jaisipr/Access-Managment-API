using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Access_Managment_API.Entities
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public string AssetName { get; set; } = "";  
        [Required]
        public int Approver1Id { get; set; }
        [Required]
        public int Approver2Id { get; set; }

        [JsonIgnore]
        public ICollection<Access_Request> AccessRequests { get; set; } = new List<Access_Request>();
    }
}
