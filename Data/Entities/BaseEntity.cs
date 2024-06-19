namespace Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAd {  get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAd { get; set;} = DateTime.UtcNow;
    }
}
