namespace ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

public class Order : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
}