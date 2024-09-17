namespace User.Api.Dto.Response
{
    public class CreateUserResponse
    {
        public int UserId { get; set; }
        public string EmailVerificationCode { get; set; }
    }
}