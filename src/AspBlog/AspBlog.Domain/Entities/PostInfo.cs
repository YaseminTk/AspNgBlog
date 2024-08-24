using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspBlog.Domain.Entities
{
    [Table("post", Schema = "blog")]
    public class PostInfo : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public required string Title { get; set; }

        [Required]
        [StringLength(100)]
        public required string Description { get; set; }
    }
}