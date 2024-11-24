using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrutura.DB;
using minimal_api.Infraestrutura.Servicos;
using minimal_api.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddScoped<iAdminstradorServico, AdminstradorServico>();
builder.Services.AddScoped<iVeiculoServico, VeiculoServico>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, iAdminstradorServico administrador) =>
{
    if (administrador.Login(loginDTO) != null)
        return Results.Ok("Logado com sucesso");
    else
        return Results.Unauthorized();
});

app.MapPost("/veiculos", (iVeiculoServico veiculoService, Veiculo veiculo) =>
{
    if (veiculoService.Incluir(veiculo) != null)
        return Results.Ok(veiculo);
    else
        return Results.Unauthorized();
});

app.MapGet("/veiculos/{id:int}", (int id, iVeiculoServico veiculoService) =>
{
    if (veiculoService.BuscarPorId(id) != null)
        return Results.Ok(veiculoService.BuscarPorId(id));
    else
        return Results.NotFound();
});

app.MapGet("/veiculos/paginas/{pagina:int}", (int pagina, iVeiculoServico veiculoService) =>
{
    if (veiculoService.Todos(pagina) != null)
        return Results.Ok(veiculoService.Todos(pagina));
    else
        return Results.NotFound();
});

app.MapDelete("/veiculos/{id:int}", (int id, iVeiculoServico veiculoService) =>
{
    Veiculo veiculo = veiculoService.BuscarPorId(id);

    if (veiculo != null) {
        veiculoService.Apagar(veiculo);
        return Results.Ok($"Veiculo de Id: {veiculo.Id}, Nome: {veiculo.Nome}, Marca: {veiculo.Marca}, Ano: {veiculo.Ano} foi excluido com sucesso!");
    }
    else
        return Results.NotFound();
});

app.MapPut("veiculos/{id:int}", (int id, iVeiculoServico veiculoServico) =>
{

});


app.UseHttpsRedirection();

app.Run();