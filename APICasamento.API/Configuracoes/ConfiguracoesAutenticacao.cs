using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace APICasamento.API.Configuracoes
{
    public static class ConfiguracoesAutenticacao
    {
        public static IServiceCollection AddConfiguracoesAutenticacao(this IServiceCollection services)
        {
            AddAutenticacao(services);
            AddAutorizacao(services);

            return services;
        }

        public static IServiceCollection AddAutenticacao(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("MINHACHAVE")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static IServiceCollection AddAutorizacao(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrador", policy => policy.RequireRole("Administrador"));
                options.AddPolicy("Clientes", policy => policy.RequireRole("Cliente", "Administrador"));
            });
            return services;
        }
    }
}
