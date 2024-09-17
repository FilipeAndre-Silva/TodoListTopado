using System.ComponentModel.DataAnnotations;

namespace User.Api.Dto.Request
{
    public class GetPasswordResetCodeRequest
    {
        [Required]
        public string Email { get; set; }
    }
}