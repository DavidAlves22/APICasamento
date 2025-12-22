using APICasamento.API.DTOs.Casamento;
using APICasamento.Application.Casamentos.Commands;
using APICasamento.Application.Casamentos.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace APICasamento.API.EndPoints
{
    public static class CasamentoEndPoint
    {
        public static void MapCasamentoEndPoints(this IEndpointRouteBuilder app)
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
                var command = new CriarCasamentoCommand(
                   casamentoDTO.NomeNoivo,
                   casamentoDTO.NomeNoiva,
                   casamentoDTO.DataCasamento,
                   casamentoDTO.LocalCerimonia,
                   casamentoDTO.LocalCelebracao
                );

                var novoId = await useCase.ExecutarAsync(command);

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
