namespace CourtCaseDomain;

public partial class Hearing
{
    public string CourtId { get; set; } = null!;

    public string TypeId { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public decimal CaseId { get; set; }

    public int No { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Record { get; set; }

    public virtual Case Case { get; set; } = null!;

    public virtual Court Court { get; set; } = null!;
}
