namespace CourtCaseDomain;

public partial class CaseWorker
{
    public string TypeId { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public decimal JobId { get; set; }

    public decimal CaseId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public virtual Case Case { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual JobPerType JobPerType { get; set; } = null!;
}
