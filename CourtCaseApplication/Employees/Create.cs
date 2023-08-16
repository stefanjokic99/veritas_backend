using FluentValidation;
using MediatR;
using CourtCasePersistance;
using CourtCase.DTOs;
using CourtCasePersistance.Infrastructure;
using CourtCaseDomain;

namespace CourtCaseApplication.Employees
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Employee EmployeeObj { get; set; }
            public string EmployeeId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.EmployeeObj).SetValidator(new EmployeeValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork<CourtCaseDataContext> _uow;
            private readonly string _failureMessage = "Greška prilikom kreiranja korisnika.";

            public Handler(IUnitOfWork<CourtCaseDataContext> uow)
            {
                _uow = uow;
             }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                request.EmployeeObj.Id = request.EmployeeId;
                await _uow.GetRepository<Employee>().InsertAsync(request.EmployeeObj, cancellationToken);
                var result = await _uow.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure(_failureMessage);

                return Result<Unit>.Success(Unit.Value);
            }

        }
    }
}
