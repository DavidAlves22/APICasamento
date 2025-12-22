using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace APICasamento.API.Configuracoes
{
    public static class ConfiguracoesAutenticacao
    {
        public static IServiceCollection AddConfiguracoesAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            AddAutenticacao(services, configuration);
            AddAutorizacao(services);

            return services;
        }

        public static IServiceCollection AddAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection("Jwt");

            var secret = jwtSection["Secret"]
                ?? throw new Exception("JWT Secret não configurado");

            var key = Encoding.UTF8.GetBytes(secret);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,

                        ValidIssuer = jwtSection["Issuer"],
                        ValidAudience = jwtSection["Audience"],
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAuthorization();

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
