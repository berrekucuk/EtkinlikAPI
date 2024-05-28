using EtkinlikAPI.Models.DTO.Activity;
using EtkinlikAPI.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly EventContext _db;
        public ActivityController(EventContext db)
        {
            _db = db;    
        }

        [HttpPost]
        public IActionResult Post(CreateActivityRequestDto model)
        {
            // Once sunucuya resimleri yazıyorum.
            List<string> imagePaths = new List<string>();
            foreach (var image in model.Images)
            {
                // Extension(uzantı) control
                if(image.ContentType != "image/jpeg" && image.ContentType != "image/jpg" && image.ContentType != "image/png")
                {
                    return BadRequest("Lütfen sadece jpeg,jpg ve png formatında resim yükleyiniz.");
                }

                //Aşağıdaki yüklenen resimlerin başına benzersiz bir Id oluşturur ve resimler arasındaki çakışmayı engeller.
                var guidName = Guid.NewGuid() + Path.GetExtension(image.FileName); 

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", guidName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                imagePaths.Add(guidName);
            }

            // Save Activity
            // Genel aktivite tablosuna insert atıyorum.
            Activity activity = new Activity()
            {
                Name = model.Name,
                Description = model.Description,
                StartDate = DateTime.Now,
                CategoryID = model.CategoryID
            };

            _db.Activities.Add(activity);
            _db.SaveChanges();

            // Save Image
            // AktiviteResimler tablosuna 'insertler' atıyorum. Kaç tane resim varsa o kadar insert atıyorum.
            foreach (var item in imagePaths)
            {
                ActivityImages activityImage = new ActivityImages();
                activityImage.ActivityID = activity.Id;
                activityImage.ImagePath = item;

                _db.ActivityImages.Add(activityImage);
            }

            _db.SaveChanges();

            return Ok();
        }
    }
}
