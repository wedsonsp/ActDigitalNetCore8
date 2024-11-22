using Ambev.DeveloperEvaluation.Application;
using Ambev.DeveloperEvaluation.Application.Clientes.CreateCliente;
using Ambev.DeveloperEvaluation.Application.Clients.CreateCliente;
using Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;
using Ambev.DeveloperEvaluation.Common.HealthChecks;
using Ambev.DeveloperEvaluation.Common.Logging;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.IoC;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Middleware;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Serilog;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Log.Information("Starting web application");

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.AddDefaultLogging();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.AddBasicHealthChecks();
            builder.Services.AddSwaggerGen();

            // Registrando repositórios
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IFilialRepository, FilialRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IVendaRepository, VendaRepository>();
            builder.Services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
            // Registrando o validador do comando
            builder.Services.AddTransient<IValidator<CreateItemVendaCommand>, CreateItemVendaCommandValidator>();

            builder.Services.AddScoped<CreateItemVendaCommandValidator>(); // Registrando o validador para DI


            builder.Services.AddDbContext<DefaultContext>(options =>
            {
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
                )
                .LogTo(Console.WriteLine, LogLevel.Information); 
            });

            builder.Logging.AddConsole();  // Adiciona o console logger


            builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                // Usando conversor para garantir o formato de data
                options.SerializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddTHH:mm:ss" });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.RegisterDependencies();

            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);
            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(UpdateVendaHandler).Assembly);
            //builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(GetVendaByIdHandler).Assembly);
            builder.Services.AddScoped<IRequestHandler<GetVendaByIdQuery, Venda>, GetVendaByIdHandler>();






            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(ApplicationLayer).Assembly,
                    typeof(UpdateVendaHandler).Assembly,
                    typeof(GetVendaByIdHandler).Assembly,
                    typeof(Program).Assembly
                );
            });

       
             
               
          

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            var app = builder.Build();
            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseBasicHealthChecks();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
