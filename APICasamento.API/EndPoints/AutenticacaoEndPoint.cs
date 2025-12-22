using APICasamento.API.DTOs.Autenticacao;
using APICasamento.Application.Autenticacao.Commands;
using APICasamento.Application.Autenticacao.UseCases;

namespace APICasamento.API.EndPoints;
public static class AutenticacaoEndPoint
{
    public static void MapAutenticacaoEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/autenticacao/login", async (
        LoginDTO dto,
        LoginUseCase useCase) =>
        {
            var token = await useCase.ExecutarAsync(
                new LoginCommand(dto.Email, dto.Password));

            return Results.Ok(new { token });
        })
        .WithName("Autenticar")
        .WithTags("Autenticacao");

        app.MapPost("api/autenticacao/registrar", async (
            RegistrarDTO dto,
            RegistrarUseCase useCase) =>
        {
            await useCase.ExecutarAsync(
                new RegistrarCommand(dto.Nome, dto.Email, dto.Password));

            return Results.Ok();
        })
        .WithName("Registrar")
        .WithTags("Autenticacao");
    }
}
