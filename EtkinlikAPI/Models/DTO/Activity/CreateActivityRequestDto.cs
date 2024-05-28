using Microsoft.AspNetCore.Http;

namespace EtkinlikAPI.Models.DTO.Activity
{
    public class CreateActivityRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public Guid CategoryID { get; set; }
        public List<IFormFile> Images { get; set; } 

        //IFromFile, API'dan resim almamızı sağlayacak yapıdır.

    }
}
