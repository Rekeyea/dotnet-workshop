namespace Entities;

public abstract class Entity
{
    public long Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public DateTime? DeletedTime { get; set; }
    public bool IsDeleted { get; set; }
}