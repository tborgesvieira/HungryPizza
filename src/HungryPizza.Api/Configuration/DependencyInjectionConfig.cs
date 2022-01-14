﻿using HungryPizza.Data;
using HungryPizza.Data.UoW;
using HungryPizza.Domain.Interfaces;

namespace HungryPizza.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServicesApi(this IServiceCollection services)
        {
            //Mapper
            services.AddAutoMapper(typeof(Program));

            //Repository
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //IUnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}