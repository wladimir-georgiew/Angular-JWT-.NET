namespace ArtCave.Web.DTO.Registration
{
    public class UserRegistrationResponse
    {
        public bool IsSuccessfulRegistration { get; set; } = false;
        public IEnumerable<string>? Errors { get; set; } = null;
    }
}
