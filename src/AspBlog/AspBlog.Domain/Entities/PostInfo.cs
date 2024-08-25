using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}