using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplierApi.Application.Interfaces;
using SupplierApi.Application.Mappings;
using SupplierApi.Application.Services;
using SupplierApi.Domain.Interfaces;
using SupplierApi.Infra.Data.Factory;
using SupplierApi.Infra.Data.Repositories;

namespace SupplierApi.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped<DbConnectionFactory>(provider =>
            {                
                return new DbConnectionFactory(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
