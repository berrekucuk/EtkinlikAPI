using System.ComponentModel.DataAnnotations.Schema;

namespace EtkinlikAPI.Models.ORM
{
    public class ActivityImages : BaseEntity
    {
        public string ImagePath { get; set; }
        public Guid ActivityID { get; set; }

        [ForeignKey("ActivityID")]
        public Activity Activity { get; set; }
    }
}
