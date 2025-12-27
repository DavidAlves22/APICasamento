using APICasamento.API.DTOs.Casamento;
using APICasamento.Application.Casamentos.Commands;
using APICasamento.Application.Casamentos.Queries;
using APICasamento.Application.Casamentos.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace APICasamento.API.EndPoints
{
    public static class CasamentoEndPoint
    {
        public static void MapCasamentoEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/casamento", async (ObterCasamentoUseCase useCase) =>
            {
                var resultado = await useCase.ExecutarAsync();
                return Results.Ok(resultado);
            })
            .WithName("GetCasamentos")
            .WithTags("Casamentos");

            app.MapGet("api/casamentos/{id:int}", async (int id, ObterCasamentoByIdUseCase useCase) =>
            {
                var resultado = await useCase.ExecutarAsync(new ObterCasamentoByIdQuery(id));

                if (resultado is null)
                    return Results.NoContent();
                return Results.Ok(resultado);
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

            app.MapPut("api/casamentos", async ([FromBody] AlterarCasamentoDTO alterarCasamentoDTO, AlterarCasamentoUseCase useCase) =>
            {
                var command = new AlterarCasamentoCommand(
                    alterarCasamentoDTO.Id,
                    alterarCasamentoDTO.NomeNoivo,
                    alterarCasamentoDTO.NomeNoiva,
                    alterarCasamentoDTO.DataCasamento,
                    alterarCasamentoDTO.LocalCerimonia,
                    alterarCasamentoDTO.LocalCelebracao
                );

                await useCase.ExecutarAsync(command);

                return Results.Ok("Casamento alterado com sucesso");
            })
            .WithName("UpdateCasamento")
            .WithTags("Casamentos");

            app.MapDelete("api/casamentos/{id}", async (int id, DeleteCasamentoUseCase useCase) =>
            {
                await useCase.ExecutarAsync(id);
                return Results.Ok($"Casamento com ID {id} deletado com sucesso");
            })
            .WithName("DeleteCasamento")
            .WithTags("Casamentos");
        }
    }
}
