namespace EtkinlikAPI.Models.ORM
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; }

    }
}
