using EtkinlikAPI.Models.DTO;
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

        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllActivityResponseDto> model = _db.Activities.Where(x => x.IsDeleted == false).Select(x => new GetAllActivityResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                StartDate = x.StartDate,
                CategoryName = x.Category.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
            }).ToList();

            // Activiteye ait resimleri çekebilmemiz için aşağıdaki foeach döngüsünü kullanıyoruz.
            foreach (var item in model)
            {
                item.Images = _db.ActivityImages.Where(x => x.ActivityID == item.Id && x.IsDeleted == false).Select(x => x.ImagePath).ToList();
            }

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var activity = _db.Activities.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if(activity == null)
            {
                return NotFound();
            }

            GetActivityResponseDto model = new GetActivityResponseDto()
            {
                Id=activity.Id,
                Name = activity.Name,
                Description = activity.Description,
                StartDate = activity.StartDate,
                CategoryName = activity.Category.Name,

                Images = _db.ActivityImages.Where(x => x.ActivityID == id && x.IsDeleted == false).Select(x => x.ImagePath).ToList()
            };

            return Ok(model);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var activity = _db.Activities.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if(activity == null)
            {
                return NotFound();
            }

            activity.IsDeleted = true;
            _db.SaveChanges();

            return Ok();
        }
    }
}
