using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AspBlog.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        [NotNull]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; init; }

        [Required]
        [NotNull]
        [Column("created_at", TypeName = "datetime2")]

        public required DateTime CreatedAt { get; init; }

        [AllowNull]
        [Column("changed_at", TypeName = "datetime2")]
        public DateTime? ChangedAt { get; set; } = null;

        [Required]
        [NotNull]
        [Column("changed_by_id")]
        public required int ChangedById { get; set; }

        [ForeignKey(nameof(ChangedById))]
        public User? ChangedBy { get; init; }
    }
}