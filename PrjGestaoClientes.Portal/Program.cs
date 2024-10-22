using Microsoft.Extensions.DependencyInjection.Extensions;
using PrjGestaoClientes.Application.Interfaces;
using PrjGestaoClientes.Application.Services;
using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.CommandSide;
using PrjGestaoClientes.Infrastructure.Context;
using PrjGestaoClientes.Infrastructure.Interfaces.CommandSide;
using PrjGestaoClientes.Infrastructure.Interfaces.Context;
using PrjGestaoClientes.Infrastructure.Interfaces.QuerySide;
using PrjGestaoClientes.Infrastructure.Interfaces.Request;
using PrjGestaoClientes.Infrastructure.QuerySide;
using PrjGestaoClientes.Infrastructure.Request;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestOperation, RequestOperation>();
builder.Services.AddScoped<IRepositorioGenerico<Cliente>, RepositorioGenerico<Cliente>>();
builder.Services.AddScoped<IRepositorioGenerico<EnderecoCliente>, RepositorioGenerico<EnderecoCliente>>();
builder.Services.AddScoped<IConsultaGenerica<Cliente>, ConsultaGenerica<Cliente>>();
builder.Services.AddScoped<IConsultaGenerica<EnderecoCliente>, ConsultaGenerica<EnderecoCliente>>();
builder.Services.AddScoped<IContext, Context>();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddMvc()
                .AddSessionStateTempDataProvider();

builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Administrar/Error");    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
