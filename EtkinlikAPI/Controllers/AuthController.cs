using EtkinlikAPI.Models.Auth;
using EtkinlikAPI.Models.DTO;
using EtkinlikAPI.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EventContext _db;
        public AuthController(EventContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Post(LoginRequestDto model)
        {
            var user = _db.AdminUsers.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null)
            {
                return BadRequest("Invalid email or password");
            }
            else
            {
                //Kullanıcı email ve şifresi doğruysa token oluştur.
                var token = EtkinlikTokenHandler.CreateToken(user.Email);
                return Ok(token);
            }


            
        }
    }
}
