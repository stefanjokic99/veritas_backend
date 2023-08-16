using CourtCase.DTOs;
using CourtCasePersistance.Infrastructure;
using CourtCasePersistance;
using FluentValidation;
using MediatR;
using AutoMapper;
using System.Runtime.InteropServices;
using CourtCaseDomain;
using System;

namespace CourtCaseApplication.Case
{
    public class Edit
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
            private readonly IMapper _mapper;

            private readonly string _failureMessage = "Greška prilikom izmjene sudskog slučaja.";

            public Handler(IUnitOfWork<CourtCaseDataContext> uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var courtCase = await _uow.GetRepository<CourtCaseDomain.Case>().FindAsync(request.CourtCase.TypeId, request.CourtCase.DepartmentId, request.CourtCase.Id);

                if (courtCase == null) return null;

                _mapper.Map(request.CourtCase, courtCase);

                var result = await _uow.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure(_failureMessage);

                return Result<Unit>.Success(Unit.Value);
            }

        }
    }
}
