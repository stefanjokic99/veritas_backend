namespace CourtCaseDomain;

public partial class CaseStatusHistory
{
    public string TypeId { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public decimal StatusId { get; set; }

    public decimal CaseId { get; set; }

    public int No { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string Judge { get; set; } = null!;

    public virtual Case Case { get; set; } = null!;

    public virtual CaseStatus Status { get; set; } = null!;
}
