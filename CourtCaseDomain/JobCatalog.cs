namespace CourtCaseDomain;

public partial class JobCatalog
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal PlannedNumber { get; set; }

    public virtual ICollection<JobPerType> JobPerTypes { get; } = new List<JobPerType>();
}
