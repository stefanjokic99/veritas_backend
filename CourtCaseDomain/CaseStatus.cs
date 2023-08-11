namespace CourtCaseDomain;

public partial class CaseStatus
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<CaseStatusHistory> CaseStatusHistories { get; } = new List<CaseStatusHistory>();

    public virtual ICollection<Case> Cases { get; } = new List<Case>();
}
