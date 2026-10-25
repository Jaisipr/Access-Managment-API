using System.ComponentModel.DataAnnotations;

namespace Access_Managment_API.DTO
{
    public class CreateAssetDto
    {
        
        public string Name { get; set; } = "";
        public int Approver1Id{ get;set;}
        public int Approver2Id { get; set; }
    }
}
