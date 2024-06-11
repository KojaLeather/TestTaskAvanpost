using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Connector.Data.Models
{
    [Table("Passwords", Schema = "TestTaskSchema")]
    public class PasswordEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("userId")]
        public string UserId { get; set; } = null!;
        [Column("password")]
        public string Password { get; set; } = null!;
    }
}
