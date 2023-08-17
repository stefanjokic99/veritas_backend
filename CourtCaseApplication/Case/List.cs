using AutoMapper;
using CourtCase.DTOs;
using CourtCasePersistance.Infrastructure;
using CourtCasePersistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CourtCasePersistance.Infrastructure.Collections;
using System.Net.WebSockets;

namespace CourtCaseApplication.Case
{
    public class List
    {
        public class Query : IRequest<Result<IPagedList<CourtCaseDto>>>
        {
            public CaseFilterParams CaseFilterParams{ get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<IPagedList<CourtCaseDto>>>
        {
            private readonly IUnitOfWork<CourtCaseDataContext> _uow;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork<CourtCaseDataContext> uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<IPagedList<CourtCaseDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var courtCase = await _uow.GetRepository<CourtCaseDomain.Case>().GetPagedListAsync(predicate: x =>
                                                                                                    (string.IsNullOrEmpty(request.CaseFilterParams.Name) || x.Name.Contains(request.CaseFilterParams.Name)) &&
                                                                                                    (string.IsNullOrEmpty(request.CaseFilterParams.TypeId) || x.TypeId == request.CaseFilterParams.TypeId) &&
                                                                                                    (string.IsNullOrEmpty(request.CaseFilterParams.DepartmentId) || x.DepartmentId == request.CaseFilterParams.DepartmentId), 
                                                                                                    pageIndex: request.CaseFilterParams.NumberOfPage,
                                                                                                    include: source => source.Include(source => source.Type).Include(source => source.Department));

                return Result<IPagedList<CourtCaseDto>>.Success(_mapper.Map<IPagedList<CourtCaseDto>>(courtCase));
            }
        }
    }
}
