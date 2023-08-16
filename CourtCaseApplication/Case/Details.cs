using AutoMapper;
using CourtCase.DTOs;
using CourtCasePersistance;
using CourtCasePersistance.Infrastructure;
using MediatR;

namespace CourtCaseApplication.Case
{
    public class Details
    {
        public class Query : IRequest<Result<CourtCaseDto>>
        {
           public CaseCompositeKeyParams CaseParams { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<CourtCaseDto>>
        {
            private readonly IUnitOfWork<CourtCaseDataContext> _uow;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork<CourtCaseDataContext> uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<CourtCaseDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var courtCase = await _uow.GetRepository<CourtCaseDomain.Case>().FindAsync(request.CaseParams.TypeId, request.CaseParams.DepartmentId, request.CaseParams.Id);

                return Result<CourtCaseDto>.Success(_mapper.Map<CourtCaseDto>(courtCase));
            }
        }
    }
}