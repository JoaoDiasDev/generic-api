﻿using joaodias_generic.Application.Mappings;
using joaodias_generic.Domain.Account;
using joaodias_generic.Domain.Interfaces;
using joaodias_generic.Infra.Data.Context;
using joaodias_generic.Infra.Data.Identity;
using joaodias_generic.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace joaodias_generic.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
         IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("GenericApiDbConnection");
            services.AddDbContext<GenericApiDbContext>(options =>
             options.UseMySql(connectionString
            , ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly(typeof(GenericApiDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GenericApiDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ICoinRepository, CoinRepository>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            var myHandlers = AppDomain.CurrentDomain.Load("joaodias_generic.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
