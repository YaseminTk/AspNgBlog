using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AspBlog.Domain.Entities
{
    [Table("post", Schema = "blog")]
    public class Post : PostInfo
    {
        [Required]
        [NotNull]
        [Column("content", TypeName = "nvarchar(max)")]
        public required string Content { get; init; }

        [Required]
        [NotNull]
        [Column("created_by_id")]
        public required int CreatedById { get; init; }

        [ForeignKey(nameof(CreatedById))]
        public User? CreatedBy { get; init; }
    }
}