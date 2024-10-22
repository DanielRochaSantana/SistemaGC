using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.Interfaces.CommandSide;
using PrjGestaoClientes.Infrastructure.CommandSide;
using PrjGestaoClientes.Infrastructure.Interfaces.QuerySide;
using PrjGestaoClientes.Infrastructure.Interfaces.Context;
using PrjGestaoClientes.Infrastructure.Context;
using PrjGestaoClientes.Infrastructure.QuerySide;
using PrjGestaoClientes.Application.Interfaces;
using PrjGestaoClientes.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IRepositorioGenerico<Cliente>, RepositorioGenerico<Cliente>>();
builder.Services.AddScoped<IRepositorioGenerico<EnderecoCliente>, RepositorioGenerico<EnderecoCliente>>();
builder.Services.AddScoped<IConsultaGenerica<Cliente>, ConsultaGenerica<Cliente>>();
builder.Services.AddScoped<IConsultaGenerica<EnderecoCliente>, ConsultaGenerica<EnderecoCliente>>();
builder.Services.AddScoped<IContext, Context>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
