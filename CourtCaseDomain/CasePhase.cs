namespace CourtCaseDomain;

public partial class CasePhase
{
    public string TypeId { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<CasePhaseHistory> CasePhaseHistories { get; } = new List<CasePhaseHistory>();

    public virtual SubjectType Type { get; set; } = null!;
}
