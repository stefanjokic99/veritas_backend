namespace CourtCaseDomain;

public partial class Case
{
    public string TypeId { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public decimal Id { get; set; }

    public decimal CurrentStatus { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CasePhaseHistory> CasePhaseHistories { get; } = new List<CasePhaseHistory>();

    public virtual ICollection<CaseStatusHistory> CaseStatusHistories { get; } = new List<CaseStatusHistory>();

    public virtual ICollection<CaseWorker> CaseWorkers { get; } = new List<CaseWorker>();

    public virtual ICollection<CourtCase> CourtCases { get; } = new List<CourtCase>();

    public virtual CaseStatus CurrentStatusNavigation { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Hearing> Hearings { get; } = new List<Hearing>();

    public virtual SubjectType Type { get; set; } = null!;
}
