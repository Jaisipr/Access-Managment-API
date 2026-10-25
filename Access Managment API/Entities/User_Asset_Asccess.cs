using System.ComponentModel.DataAnnotations;

namespace Access_Managment_API.Entities
{
    public class User_Asset_Asccess
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AssetId { get; set; }
    }
}
