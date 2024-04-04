using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalPlayGround.ClientInfo
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}