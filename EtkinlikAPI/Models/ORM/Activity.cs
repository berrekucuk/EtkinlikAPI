using System.ComponentModel.DataAnnotations.Schema;

namespace EtkinlikAPI.Models.ORM
{
    public class Activity :BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public bool IsPopular { get; set; } = false;
        public Guid CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}
