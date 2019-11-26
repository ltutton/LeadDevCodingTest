using System.ComponentModel.DataAnnotations;

namespace UserList.Api.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string FamilyName { get; set; }
    }
}