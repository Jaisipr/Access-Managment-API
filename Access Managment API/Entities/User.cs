using System.ComponentModel.DataAnnotations;

namespace Access_Managment_API.Entities
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        public string UserName { get; set; } = "";
    }
}
