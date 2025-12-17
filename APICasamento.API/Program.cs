using APICasamento.API.Configuracoes;
using APICasamento.API.EndPoints;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDependencyInjection(builder.Configuration);
builder.Services.AddSwagger();

builder.Services.AddConfiguracoesAutenticacao();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

//Mapeamento dos endpoints
app.MapGet("/public", () => Results.Ok("Este é um endpoint público. Qualquer um pode acessá-lo.")).AllowAnonymous();
app.MapCasamentoEndpoints();

app.Run();
