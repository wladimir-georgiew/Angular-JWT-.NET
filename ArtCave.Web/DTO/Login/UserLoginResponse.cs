namespace ArtCave.Web.DTO.Login
{
    public class UserLoginResponse
    {
        public bool IsAuthSuccessful { get; set; } = false;

        public string? ErrorMessage { get; set; } = null;

        public string? Token { get; set; } = null;
    }
}
