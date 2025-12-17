using APICasamento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace APICasamento.API.Configuracoes
{
    public static class ConfiguracaoBancoDeDados
    {
        public static IServiceCollection ConfigureDataBase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(optionsAction =>
            {
                optionsAction.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();

            var mySQLConnection = configuration.GetConnectionString("DefaultConnection");

            ConfigureDataBase(services, mySQLConnection);

            return services;
        }
    }
}
