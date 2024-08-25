using AspBlog.Abstractions.DTOs.Base;
using System.Text.Json.Serialization;

namespace AspBlog.Abstractions.DTOs.User
{
    public record UserUpdateDto(
        int Id,
        string UserName,
        string FullName,
        string Role
        ) : BaseUpdateDto(Id)
    {
        [JsonIgnore]
        public int ChangedById { get; set; }
    };
}