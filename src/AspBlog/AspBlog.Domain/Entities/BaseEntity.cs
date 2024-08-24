using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspBlog.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        public required DateTime CreatedAt { get; init; }

        [Required]
        public DateTime? ChangedAt { get; set; } = null;
    }
}