namespace ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; }
    public DateTimeOffset? DeletionDate { get; set; }
    public DateTimeOffset CreationDate { get; set; }
}