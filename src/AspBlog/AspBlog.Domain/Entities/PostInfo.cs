using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AspBlog.Domain.Entities
{
    [Table("post", Schema = "blog")]
    public class PostInfo : BaseEntity
    {
        [Required]
        [StringLength(50)]
        [Column("title")]
        public required string Title { get; set; }

        [Required]
        [StringLength(100)]
        [Column("description")]
        public required string Description { get; set; }

        [Required]
        [NotNull]
        [Column("created_by_id")]
        public required int CreatedById { get; init; }

        [ForeignKey(nameof(CreatedById))]
        public User? CreatedBy { get; init; }

        [NotMapped]
        public string? Author => CreatedBy?.FullName;
    }
}