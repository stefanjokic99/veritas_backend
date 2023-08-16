using FluentValidation;

namespace CourtCaseApplication.Employees
{
    public class EmployeeValidator : AbstractValidator<CourtCaseDomain.Employee>
    {
        private readonly string _forenameMessage = "Ime je obavezno.";
        private readonly string _surenameMessage = "Prezime je obavezno.";
        private readonly string _sexMessage = "Pol može biti označen samo sa M ili Z.";
        private readonly string _JmbgMessage = "JMBG mora imati 13 cifara.";


        public EmployeeValidator() 
        {
            RuleFor(x => x.Forename).NotEmpty().WithMessage(_forenameMessage);
            RuleFor(x => x.Surename).NotEmpty().WithMessage(_surenameMessage) ;
            RuleFor(x => x.Sex).NotEmpty().Must(x => x == "M" || x == "Z").WithMessage(_sexMessage);
            RuleFor(x => x.Jmbg).NotEmpty().Length(13).Matches("^[0-9]*$").WithMessage(_JmbgMessage);
        }
    }
}
