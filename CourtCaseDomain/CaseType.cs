namespace CourtCaseDomain;

public partial class CaseType
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<CasePhase> CasePhases { get; } = new List<CasePhase>();

    public virtual ICollection<Case> Cases { get; } = new List<Case>();

    public virtual ICollection<JobPerType> JobPerTypes { get; } = new List<JobPerType>();
}
