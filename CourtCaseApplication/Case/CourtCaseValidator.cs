using FluentValidation;

namespace CourtCaseApplication.Case
{
    public class CourtCaseValidator : AbstractValidator<CourtCaseDomain.Case>
    {
        private readonly string _departmentIdMessage = "Obavezno je navesti odjeljenje kome pripada sudski predmet.";
        private readonly string _typeIdMessage = "Obavezno je navesti vrstu sudskog predmeta.";
        private readonly string _nameMessage = "Obavezno je navesti ime sudskog predmeta.";
        private readonly string _currentStatusMessage = "Obavezno je navesti trenutno stanje sudskog predmeta.";


        public CourtCaseValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty().WithMessage(_typeIdMessage);
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage(_departmentIdMessage);
            RuleFor(x => x.CurrentStatus).NotEmpty().WithMessage(_currentStatusMessage);
            RuleFor(x => x.Name).NotEmpty().WithMessage(_nameMessage);
        }
    }
}
