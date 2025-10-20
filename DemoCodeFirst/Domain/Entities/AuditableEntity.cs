namespace DemoCodeFirst.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDateOnUtc { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateOnUtc { get; set; }
    }
}
