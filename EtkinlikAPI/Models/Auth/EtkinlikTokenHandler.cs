using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EtkinlikAPI.Models.Auth
{
    public class EtkinlikTokenHandler
    {
        public static JWTToken CreateToken(string email)
        {
            var responseModel = new JWTToken();

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,email),
            };

            // Token oluştururken bir şifre istiyor bu şifreyi SymmetricSecurityKey classı sağlıyor.Bu classa da string bir şifre veriyoruz.
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ironmaidenpentagramslipknotironmaidenpentagramslipknot"));

            //Token imzalama(şifreleme) algoritması
            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            // Token oluşturma
            responseModel.AccessTokenExpiration = System.DateTime.Now.AddMinutes(30);

            //Oluşturulan Token özellikleri
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: "berre@mail.com",
                audience: "berre1@mail.com",
                expires: responseModel.AccessTokenExpiration,
                signingCredentials: credentials,
                claims: claims
             );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            responseModel.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);
            return responseModel;




        }
    }
}
