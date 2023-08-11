namespace CourtCaseDomain;

public partial class EmployeeInDepartment
{
    public string DepartmentId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public decimal No { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
