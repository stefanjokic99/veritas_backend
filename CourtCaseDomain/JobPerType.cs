namespace CourtCaseDomain;

public partial class JobPerType
{
    public string TypeId { get; set; } = null!;

    public decimal JobId { get; set; }

    public virtual ICollection<CaseWorker> CaseWorkers { get; } = new List<CaseWorker>();

    public virtual JobCatalog Job { get; set; } = null!;

    public virtual SubjectType Type { get; set; } = null!;
}
