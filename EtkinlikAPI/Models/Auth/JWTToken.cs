namespace EtkinlikAPI.Models.Auth
{
    public class JWTToken
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
