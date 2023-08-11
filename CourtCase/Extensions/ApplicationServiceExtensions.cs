using Microsoft.EntityFrameworkCore;
using CourtCasePersistance;
using CourtCasePersistance.Infrastructure;

namespace CourtCase.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            //Add Framework Services & Options, we use the current assembly to get classes. 

            return services;
        }
    }
}
