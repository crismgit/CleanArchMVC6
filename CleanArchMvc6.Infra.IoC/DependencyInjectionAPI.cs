using CleanArchMvc6.Application.Interfaces;
using CleanArchMvc6.Application.Mappings;
using CleanArchMvc6.Application.Services;
using CleanArchMvc6.Domain.Account;
using CleanArchMvc6.Domain.Interfaces;
using CleanArchMvc6.Infra.Data.Context;
using CleanArchMvc6.Infra.Data.Identity;
using CleanArchMvc6.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CleanArchMvc6.Infra.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
        ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddScoped<IAuthenticate, AuthenticateService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc6.Application");
        services.AddMediatR(myhandlers);

        return services;
    }
}
