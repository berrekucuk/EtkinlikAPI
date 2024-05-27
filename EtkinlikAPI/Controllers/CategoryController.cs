using EtkinlikAPI.Models.DTO;
using EtkinlikAPI.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EventContext _db;
        public CategoryController(EventContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllCategoryResponseDto> categories = _db.Categories.Where(x => x.IsDeleted == false).Select(x => new GetAllCategoryResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                AddDate = x.AddDate,
            }).OrderBy(q => q.AddDate).ToList();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entity = _db.Categories.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                GetCategoryResponseDto model = new GetCategoryResponseDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    AddDate = entity.AddDate,
                };

                return Ok(model);
            }
        }


        [HttpPost]
        public IActionResult Post(CreateCategoryRequestDto model)
        {
            var entity = new Category
            {
                Name = model.Name,
            };

            _db.Categories.Add(entity);
            _db.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = _db.Categories.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.IsDeleted = true;
                entity.DeleteDate = DateTime.Now;
                _db.SaveChanges();

                return Ok();
            }
        }



    }

}
