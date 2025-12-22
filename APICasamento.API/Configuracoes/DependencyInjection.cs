using APICasamento.Application.Autenticacao.Interfaces;
using APICasamento.Application.Autenticacao.UseCases;
using APICasamento.Application.Casamentos.Interfaces;
using APICasamento.Application.Casamentos.UseCases;
using APICasamento.Infrastructure.Autenticacao;
using APICasamento.Infrastructure.Repositories;

namespace APICasamento.API.Configuracoes
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositórios
            services.AddScoped<ICasamentoRepository, CasamentoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Services
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            //Use Cases
            services.AddScoped<CriarCasamentoUseCase>();
            services.AddScoped<LoginUseCase>();
            services.AddScoped<RegistrarUseCase>();

            return services;
        }
    }
}
