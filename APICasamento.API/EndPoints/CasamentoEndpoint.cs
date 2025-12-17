using APICasamento.Application.DTOs;
using APICasamento.Application.UseCases.CasamentoUseCases;
using Microsoft.AspNetCore.Mvc;

namespace APICasamento.API.EndPoints
{
    public static class CasamentoEndpoint
    {
        public static void MapCasamentoEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/casamento", () =>
            {
                return Results.Ok("Lista de casamentos");
            })
            .WithName("GetCasamentos")
            .WithTags("Casamentos");

            app.MapGet("api/casamentos/{id}", (int id) =>
            {
                return Results.Ok($"Detalhes do casamento com ID {id}");
            })
            .WithName("GetCasamentoById")
            .WithTags("Casamentos");

            app.MapPost("api/casamentos", async ([FromBody] CriarCasamentoDTO casamentoDTO, CriarCasamentoUseCase useCase) =>
            {
                var novoId = await useCase.ExecutarAsync(casamentoDTO);

                return Results.Created($"api/casamentos/{novoId}", "Casamento criado com sucesso");
            })
            .WithName("CreateCasamento")
            .WithTags("Casamentos");

            app.MapPut("api/casamentos/{id}", (int id) =>
            {
                return Results.Ok($"Casamento com ID {id} atualizado com sucesso");
            })
            .WithName("UpdateCasamento")
            .WithTags("Casamentos");

            app.MapDelete("api/casamentos/{id}", (int id) =>
            {
                return Results.Ok($"Casamento com ID {id} deletado com sucesso");
            })
            .WithName("DeleteCasamento")
            .WithTags("Casamentos");
        }
    }
}
