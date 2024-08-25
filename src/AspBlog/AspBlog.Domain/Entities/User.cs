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
        public required string Role { get; set; } = "user";

        [Required]
        [NotNull]
        [Column("changed_by_id")]
        public required int ChangedById { get; set; }

        [ForeignKey(nameof(ChangedById))]
        public User? ChangedBy { get; init; }
    }
}