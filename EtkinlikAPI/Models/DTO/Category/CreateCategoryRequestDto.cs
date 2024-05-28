using System.ComponentModel.DataAnnotations;

namespace EtkinlikAPI.Models.DTO
{
    public class CreateCategoryRequestDto
    {
        // [Required(ErrorMessage = "Name is required")]  => Dilerseniz validationları bu bölgeye de yazabilirsiniz.
        public string Name { get; set; }
    }
}
