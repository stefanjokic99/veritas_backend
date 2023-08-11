namespace CourtCaseDomain;

public partial class Employee
{
    public string Id { get; set; } = null!;

    public string Surename { get; set; } = null!;

    public string? ParentName { get; set; }

    public string Forename { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public string Jmbg { get; set; } = null!;

    public virtual ICollection<CaseWorker> CaseWorkers { get; } = new List<CaseWorker>();

    public virtual ICollection<EmployeeInDepartment> EmployeeInDepartments { get; } = new List<EmployeeInDepartment>();
}
