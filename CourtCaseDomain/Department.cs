namespace CourtCaseDomain;


public partial class Department
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Case> Cases { get; } = new List<Case>();

    public virtual ICollection<EmployeeInDepartment> EmployeeInDepartments { get; } = new List<EmployeeInDepartment>();
}
