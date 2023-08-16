using CourtCaseDomain;

namespace CourtCasePersistance
{
    public class Seed
    {
        public static async Task SeedData(CourtCaseDataContext _context)
        {
            if (!_context.Departments.Any() && !_context.CaseTypes.Any())
            {
                List<Department> departments = new List<Department>
                {
                    new Department { Id = "Korp", Name = "Korporativno/pravo društava" },
                    new Department { Id = "Fin", Name = "Financijsko pravo" },
                    new Department { Id = "Trg", Name = "Trgovinsko pravo" },
                    new Department { Id = "Rad", Name = "Radno pravo" },
                    new Department { Id = "Imo", Name = "Imovinsko pravo" },
                    new Department { Id = "Intl", Name = "Intelektualno vlasništvo" },
                    new Department { Id = "Krim", Name = "Krivično pravo" },
                    new Department { Id = "Pin", Name = "Porodično i nasljedno pravo" },
                    new Department { Id = "Up", Name = "Upravno pravo" },
                    new Department { Id = "M", Name = "Međunarodno pravo" }
                };

                var types = new List<CaseType>
                {
                    new CaseType { Id = "K", Name = "Krivični predmeti" },
                    new CaseType { Id = "Km", Name = "Krivični predmeti - maloljetnici" },
                    new CaseType { Id = "P", Name = "Parnični predmeti" },
                    new CaseType { Id = "Mal", Name = "Parnični predmeti - mala vrijednost" },
                    new CaseType { Id = "Ps", Name = "Privredni predmeti" },
                    new CaseType { Id = "Mals", Name = "Privredni predmeti - mala vrijednost" },
                    new CaseType { Id = "V", Name = "Vanparnični predmeti" },
                    new CaseType { Id = "O", Name = "Ostavinski predmeti" },
                    new CaseType { Id = "I", Name = "Izvršenje građansko" },
                    new CaseType { Id = "Ip", Name = "Izvršenje privredno" },
                    new CaseType { Id = "St", Name = "Stečajni predmeti" },
                    new CaseType { Id = "L", Name = "Likvidacioni predmeti" },
                    new CaseType { Id = "U", Name = "Upravni spor" },
                    new CaseType { Id = "Su", Name = "Sudska uprava" },
                    new CaseType { Id = "Pi", Name = "Deponiranje testamenta" },
                    new CaseType { Id = "Zzp", Name = "Založno pravo" },
                    new CaseType { Id = "Pr", Name = "Prekršajni predmeti" },
                    new CaseType { Id = "Rs", Name = "Radni sporovi" },
                    new CaseType { Id = "Dn", Name = "Zemljišnoknjižni predmeti" },
                    new CaseType { Id = "Reg", Name = "Registar pravnih lica" },
                    new CaseType { Id = "KPU", Name = "Knjiga položenih ugovora" },
                };

                var statuses = new List<CaseStatus>
                {
                    new CaseStatus
                    {
                        Id = 1, 
                        Name = "OTVOREN"
                    },
                    new CaseStatus
                    {
                        Id = 2,
                        Name = "ISKAZAN ZAVRSENIM"
                    },
                    new CaseStatus
                    {
                        Id = 1,
                        Name = "ARHIVIRAN"
                    }
                };
                await _context.Departments.AddRangeAsync(departments);
                await _context.CaseTypes.AddRangeAsync(types);
                await _context.CaseStatuses.AddRangeAsync(statuses);

                await _context.SaveChangesAsync();
            }
        }

    }
}
