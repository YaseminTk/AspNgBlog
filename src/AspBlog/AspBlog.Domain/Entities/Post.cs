using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspBlog.Domain.Entities
{
    [Table("post", Schema = "blog")]
    public class Post : PostInfo
    {
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public required string Content { get; set; }
    }
}