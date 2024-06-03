using EtkinlikAPI.Models.DTO;
using EtkinlikAPI.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly EventContext _db;
        public BlogPostController(EventContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllBlogPostResponseDto> model = _db.BlogPosts.Where(x => x.IsDeleted == false).Select(x => new GetAllBlogPostResponseDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
            }).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var blogPost = _db.BlogPosts.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (blogPost == null)
            {
                return NotFound();
            }

            GetBlogPostResponseDto model = new GetBlogPostResponseDto()
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
            };

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateBlogPostRequestDto model)
        {
            var entity = new BlogPost
            {
                Title = model.Title,
                Content = model.Content,
            };

            _db.BlogPosts.Add(entity);
            _db.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = _db.BlogPosts.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (entity == null)
            {
                return NotFound();
            }

            entity.IsDeleted = true;

            _db.SaveChanges();

            return Ok();
        }
    }
}
