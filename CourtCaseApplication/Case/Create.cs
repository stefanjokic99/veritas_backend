using CourtCase.DTOs;
using CourtCasePersistance.Infrastructure;
using CourtCasePersistance;
using FluentValidation;
using MediatR;

namespace CourtCaseApplication.Case
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CourtCaseDomain.Case CourtCase { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.CourtCase).SetValidator(new CourtCaseValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork<CourtCaseDataContext> _uow;
            private readonly string _failureMessage = "Greška prilikom kreiranja sudskog slučaja.";

            public Handler(IUnitOfWork<CourtCaseDataContext> uow)
            {
                _uow = uow;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                request.CourtCase.StartDate = DateTime.UtcNow;
                await _uow.GetRepository<CourtCaseDomain.Case>().InsertAsync(request.CourtCase, cancellationToken);                
                var result = await _uow.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure(_failureMessage);

                return Result<Unit>.Success(Unit.Value);
            }

        }
    }
}
