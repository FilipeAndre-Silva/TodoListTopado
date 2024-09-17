using System.ComponentModel.DataAnnotations;

namespace User.Api.Dto.Request
{
    public class ActivationUserRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string ActivationCode { get; set; }
    }
}