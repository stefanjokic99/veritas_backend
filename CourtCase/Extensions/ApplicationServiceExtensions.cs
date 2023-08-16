using Microsoft.EntityFrameworkCore;
using CourtCasePersistance;
using CourtCasePersistance.Infrastructure;
using MediatR;
using FluentValidation.AspNetCore;
using FluentValidation;
using CourtCaseApplication.Employees;
using CourtCaseApplication.Core;

namespace CourtCase.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddMediatR(typeof(Create.Command));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<CourtCaseDataContext>(opt =>
            {

                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            
            services.AddUnitOfWork<CourtCaseDataContext>();


            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://veritas_backend");
                });
            });

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CourtCaseApplication.Employees.Create>();
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);


            //Add Framework Services & Options, we use the current assembly to get classes. 

            return services;
        }
    }
}
