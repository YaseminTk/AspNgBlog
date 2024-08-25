using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AspBlog.Domain.Entities
{
    [Table("user", Schema = "blog")]
    public class User : BaseEntity
    {
        [Required]
        [NotNull]
        [StringLength(50)]
        [Column("user_name")]
        public required string UserName { get; set; }

        [Required]
        [NotNull]
        [StringLength(50)]
        [Column("full_name")]
        public required string FullName { get; set; }

        [Required]
        [NotNull]
        [StringLength(100)]
        [Column("password_hash")]
        public required string PasswordHash { get; set; }

        [Required]
        [NotNull]
        [StringLength(20)]
        [Column("role")]
        public required string Role { get; set; }
    }
}