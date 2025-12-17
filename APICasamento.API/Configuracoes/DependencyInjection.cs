using APICasamento.Application.Repositories;
using APICasamento.Application.UseCases.CasamentoUseCases;
using APICasamento.Infrastructure.Repositories;

namespace APICasamento.API.Configuracoes
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositórios
            services.AddScoped<ICasamentoRepository, CasamentoRepository>();

            //Use Cases
            services.AddScoped<CriarCasamentoUseCase>();

            return services;
        }
    }
}
