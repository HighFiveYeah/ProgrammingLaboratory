namespace ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}