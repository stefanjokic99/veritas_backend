namespace CourtCaseDomain;

public partial class CasePhaseHistory
{
    public string TypeId { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public string PhaseId { get; set; } = null!;

    public decimal CaseNo { get; set; }

    public int No { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Case Case { get; set; } = null!;

    public virtual CasePhase CasePhase { get; set; } = null!;
}
