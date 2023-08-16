using AutoMapper;
using CourtCaseApplication.Case;

namespace CourtCaseApplication.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<CourtCaseDomain.Case, CourtCaseDomain.Case>();
            CreateMap<CourtCaseDomain.Department, DepartmentDto>();
            CreateMap<CourtCaseDomain.CaseType, CaseTypeDto>();
            CreateMap<CourtCaseDomain.Case, CourtCaseDto>() 
                .ForMember(d => d.Status, o => o.MapFrom(s => s.CurrentStatusNavigation.Name));
        }
    }
}
