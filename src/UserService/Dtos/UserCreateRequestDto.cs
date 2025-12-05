using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserService.Dtos
{
    public class UserCreateRequestDto
    {
        [JsonPropertyName("userName")]
        [Required(AllowEmptyStrings = false)]
        public required string UserName { get; set; }

        [JsonPropertyName("firstName")]
        [Length(3, 20)]
        public required string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        [Length(3, 20)]
        public required string LastName { get; set; }

        [JsonPropertyName("email")]
        [EmailAddress]
        public required string Email { get; set; }

        [JsonPropertyName("phone")]
        [StringLength(11)]
        public required string Phone { get; set; }
    }
}
