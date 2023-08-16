namespace CourtCaseApplication.Case
{
    public class CaseFilterParams
    {
        public int NumberOfPage { get; set; }

        public string TypeId { get; set; } = String.Empty;

        public string DepartmentId { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;
    }
}
