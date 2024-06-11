using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Connector.Data.Models
{
    [Table("User", Schema = "TestTaskSchema")]
    public class User
    {
        [Key]
        [Column("login")]
        public string Login { get; set; } = null!;

        [Column("lastName")]
        public string? LastName { get; set; }

        [Column("firstName")]
        public string? FirstName { get; set; }

        [Column("middleName")]
        public string? MiddleName { get; set; }

        [Column("telephoneNumber")]
        public string? TelephoneNumber { get; set; }

        [Column("isLead")]
        public bool IsLead { get; set; }
    }
}
