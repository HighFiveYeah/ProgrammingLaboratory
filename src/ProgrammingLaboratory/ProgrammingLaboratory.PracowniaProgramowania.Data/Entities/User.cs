namespace ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string Address { get; set; } = null!;
}