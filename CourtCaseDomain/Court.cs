namespace CourtCaseDomain;

public partial class Court
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<CourtCase> CourtCases { get; } = new List<CourtCase>();

    public virtual ICollection<Hearing> Hearings { get; } = new List<Hearing>();
}
