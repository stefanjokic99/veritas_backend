namespace CourtCaseApplication.Case
{
    public class CourtCaseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }   
        
        public string Description { get; set; } 

        public string Status { get; set; }  

        public CaseTypeDto Type { get; set; }
        
        public DepartmentDto Department { get; set; }
       
    }
}
