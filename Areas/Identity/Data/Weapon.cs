namespace AuthSystem.Areas.Identity.Data
{
    public class Weapon
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}
