using System.ComponentModel.DataAnnotations;

namespace Access_Managment_API.Entities
{
    public class Access_Request
    {
        [Required]
        public int RequestId { get; set; }
        [Required]
        public int AssetId { get; set; }
        [Required]
        public int RequesterId { get; set; }
        public string Status { get; set; } = "In progress";
    }
}
