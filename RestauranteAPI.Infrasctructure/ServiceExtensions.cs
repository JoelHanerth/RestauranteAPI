using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteAPI.Domain.Interfaces;
using RestauranteAPI.Domain.Interfaces.Common;
using RestauranteAPI.Domain.Shared;
using RestauranteAPI.Infrastructure.Context;
using RestauranteAPI.Infrastructure.Repositories;
using RestauranteAPI.Infrastructure.Repositories.Common;
//injecao de dependencia
namespace RestauranteAPI.Infrasctructure
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            IServiceCollection ServiceCollection = services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(RestauranteAPIEnvironment.SqlServer, x => x.MigrationsAssembly("RestauranteAPI.Infracture"));
                opt.EnableSensitiveDataLogging();
            }, ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}
