using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserService.Dtos
{
    public class UserUpdateRequestDto
    {
        [JsonPropertyName("firstName")]
        [Length(3, 20)]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        [Length(3, 20)]
        public string? LastName { get; set; }

        [JsonPropertyName("email")]
        [EmailAddress]
        public string? Email { get; set; }

        [JsonPropertyName("phone")]
        [StringLength(11)]
        public string? Phone { get; set; }
    }
}
